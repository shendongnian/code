    public Startup(IHostingEnvironment env)
	{
		var builder = new ConfigurationBuilder()
			.SetBasePath(env.ContentRootPath)
			.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
		
		builder.AddEnvironmentVariables();
		Configuration = builder.Build();
		
	}
	
	public IConfigurationRoot Configuration { get; }
	
	public void ConfigureServices(IServiceCollection services)
    {
		services.AddHangfire(configuration => 
		configuration.UseSqlServerStorage(Configuration.GetConnectionString("HangfireDemo"))
		);  
		
	}
