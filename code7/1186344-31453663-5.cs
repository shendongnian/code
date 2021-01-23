	public void ConfigureServices(IServiceCollection services)
	{
		services.AddMvc();
	
		// Add functionality to inject IOptions<T>
		services.AddOptions();
		
		// Add our Config object so it can be injected
		services.Configure<MyConfig>(Configuration);
	}
