    public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
    {
          // Setup configuration sources.
          var builder = new ConfigurationBuilder()
                    .SetBasePath(appEnv.ApplicationBasePath)
                    .AddJsonFile("config.json")
                    .AddJsonFile($"config.{env.EnvironmentName}.json", true)
                    .AddEnvironmentVariables();
          Configuration = builder.Build();
    }
    
    public IConfigurationRoot Configuration { get; set; }
    public void ConfigureServices(IServiceCollection services)
    {
            var builder = services.AddMvc();
           services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
    }
