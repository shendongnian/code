    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddSingleton<IFooService, FooService>();
    
        // Build the intermediate service provider
    	var sp = services.BuildServiceProvider();
        // This will succeed.
    	var fooService = sp.GetService<IFooService>();
        // This will fail (return null), as IBarService hasn't been registered yet.
    	var barService = sp.GetService<IBarService>();
    }
