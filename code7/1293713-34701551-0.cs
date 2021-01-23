    public static IConfigurationRoot Configuration;
    public Startup(IApplicationEnvironment appEnv)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(appEnv.ApplicationBasePath)
            .AddJsonFile("appsettings.json") // You're probably missing this part
            .AddEnvironmentVariables();
        Configuration = builder.Build();
    }
