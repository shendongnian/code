	public void ConfigureServices(IServiceCollection services)
	{
		...
		// Add the whole configuration object here.
		services.AddSingleton<IConfiguration>(Configuration);
	}
	
