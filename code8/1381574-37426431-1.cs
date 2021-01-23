    public void ConfigureServices(IServiceCollection services)
    {
        // Setup options with DI
        services.AddOptions();
        
        // Configure ConnectionStrings using config
        services.Configure<ConnectionStrings>(Configuration);
    }
