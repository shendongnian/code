    public void ConfigureServices(IServiceCollection services)
	{
		services
			.AddSingleton<IActionContextAccessor, ActionContextAccessor>()
			.AddMvc();
	}
