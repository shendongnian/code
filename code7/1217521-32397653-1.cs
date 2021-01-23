    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<AppSettings>(Config.GetSection("AppSettings"));
    
        // ...
    }
