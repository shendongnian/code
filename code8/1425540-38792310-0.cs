    public Startup(IHostingEnvironment env)
	{
		var builder = new ConfigurationBuilder()
			.SetBasePath(env.ContentRootPath)
			.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
		
		Configuration = builder.Build();
		
		environment = env;
	}
	public IHostingEnvironment environment { get; set; }
	public IConfigurationRoot Configuration { get; }
	
	public void ConfigureServices(IServiceCollection services)
    {
		// you can access environment.ContentRootPath here
	}
