    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.Configuration;
    using System.IO;
    
    public class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
    
            ConfigureServices(serviceCollection);
    
            // Application application = new Application(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
    
            var app = serviceProvider.GetService<Application>();
    
            // For async
            Task.Run(() => app.Run()).Wait(); // Exceptions thrown here will be lost! Catch them all at Run()
                                                // For sync
            app.Run();            
        }
    
        private static void ConfigureServices(IServiceCollection services)
        {
            ILoggerFactory loggerFactory = new LoggerFactory()
                .AddConsole()
                .AddDebug();
    
            services.AddSingleton(loggerFactory); // Add first my already configured instance
            services.AddLogging(); // Allow ILogger<T>
    
            IConfigurationRoot configuration = GetConfiguration();
            services.AddSingleton<IConfigurationRoot>(configuration);
    
            // Support typed Options
            services.AddOptions();
            services.Configure<MyOptions>(configuration.GetSection("MyOptions"));  
    
            services.AddTransient<Application>();
        }
    
        private static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: true)
                .Build();
        }
    }
    
    public class MyOptions
    {
        public string Name { get; set; }
    }
    
    public class Application
    {
        ILogger _logger;
        MyOptions _settings;
    
        public Application(ILogger<Application> logger, IOptions<MyOptions> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }
    
        public async Task Run()
        {
            try
            {
                _logger.LogInformation($"This is a console application for {_settings.Name}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
    }
