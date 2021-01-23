    public void ConfigureService(IServiceCollection services)
    {
        // Configure the services
        services.AddTransient<IFooService, FooServiceImpl>();
        services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
    
        // Build an intermediate service provider
    	var sp = services.BuildServiceProvider();
        // Resolve the services from the service provider
        var fooService = sp.GetService<IFooService>();
        var options = sp.GetService<IOptions<AppSettings>>();
    }
