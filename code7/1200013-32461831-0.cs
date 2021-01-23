    public void ConfigureService(IServiceCollection services)
    {
    	services.AddTransient<ISomeService, SomeService>();
    
    	var sp = services.BuildServiceProvider();
    	var service = sp.GetService<ISomeService>();
    }
