    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<CustomSettings>(Configuration.GetSection("CustomSettings"));
        ...
    }
