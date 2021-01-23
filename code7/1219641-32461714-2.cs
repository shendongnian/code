    public void ConfigureService(IServiceCollection services)
    {
    	services.AddSingleton<ISomeService, SomeService>();
    
        // Build the intermediate service provider
    	var sp = services.BuildServiceProvider();
    	var service = sp.GetService<ISomeService>();
    }
