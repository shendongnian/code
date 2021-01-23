            using Microsoft.Extensions.Configuration;
            using Microsoft.Extensions.DependencyInjection;
            using Microsoft.Extensions.Logging;
            [...]
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            var serviceProvider = new ServiceCollection()
                .AddLogging(options => options.AddConfiguration(configuration).AddConsole())
                .AddSingleton<IConfiguration>(configuration)
                .AddSingleton<SomeService>()
                .BuildServiceProvider();
            [...]
            await serviceProvider.GetService<SomeService>().Start();
