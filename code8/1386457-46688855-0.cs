    public abstract class TestBase
    {
        protected readonly DateTime UtcNow;
        protected readonly ObjectMother ObjectMother;
        protected readonly HttpClient RestClient;
    
        protected TestBase()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
    
            var connectionStringsAppSettings = new ConnectionStringsAppSettings();
            configuration.GetSection("ConnectionStrings").Bind(connectionStringsAppSettings);
    
            //You can now access your appsettings with connectionStringsAppSettings.MYKEY
    
            UtcNow = DateTime.UtcNow;
            ObjectMother = new ObjectMother(UtcNow, connectionStringsAppSettings);
            WebHostBuilder webHostBuilder = new WebHostBuilder();
            webHostBuilder.ConfigureServices(s => s.AddSingleton<IStartupConfigurationService, TestStartupConfigurationService>());
            webHostBuilder.UseStartup<Startup>();
            TestServer testServer = new TestServer(webHostBuilder);
            RestClient = testServer.CreateClient();
        }
    }
