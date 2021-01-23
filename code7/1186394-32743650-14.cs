    public IConfiguration Configuration { get; set; }
    public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
    {
         var configurationBuilder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
            .AddJsonFile("config.json")
            .AddEnvironmentVariables();
         Configuration = configurationBuilder.Build();
    }
