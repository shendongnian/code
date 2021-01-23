    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IMyService, MyService>();
    
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetService<IMyService>();
    }
