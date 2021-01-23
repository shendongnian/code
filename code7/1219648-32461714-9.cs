    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddSingleton<IFooService, FooService>();
    
        // Build the intermediate service provider
    	var sp = services.BuildServiceProvider();
    	var fooService = sp.GetService<IFooService>();
    }
