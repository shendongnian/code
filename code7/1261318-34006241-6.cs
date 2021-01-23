    public IConfiguration Configuration { get; private set; }
    public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv) {
      IConfigurationBuilder configBuilder = new ConfigurationBuilder()
        .SetBasePath(appEnv.ApplicationBasePath)
        .AddJsonFile("Database.json")
        .AddEnvironmentVariables()
      Configuration = configBuilder.Build();
    }
