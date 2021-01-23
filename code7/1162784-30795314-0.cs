    public IConfiguration Configuration { get; private set; }
    
    public Startup(IHostingEnvironment env)
    {
        Configuration = new Configuration()
            .AddJsonFile("config.json")
            .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);
    }
