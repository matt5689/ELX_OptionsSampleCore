using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace OptionsSampleCore
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly AppSettings _appSettings;

        public App(IOptionsMonitor<AppSettings> appSettings, ILogger<App> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _appSettings = appSettings?.CurrentValue ?? throw new ArgumentNullException(nameof(appSettings));
        }

        public async Task Run(string[] args)
        {
            _logger.LogInformation("Starting...");

            while (true)
            {
                Console.WriteLine("App Start!");
                Console.WriteLine(_appSettings.TempDirectoryPath);
                System.Threading.Thread.Sleep(1000);
            }

            _logger.LogInformation("App Finished!");

            await Task.CompletedTask;
        }
    }
}