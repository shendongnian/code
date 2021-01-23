    private IConfiguration Configuration { get; }
    
    public Startup(IApplicationEnvironment appEnv)
    {
        var configurationBuilder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
            .AddJsonFile("config.json")
            .AddEnvironmentVariables();
    
        Configuration = configurationBuilder.Build();
    }
