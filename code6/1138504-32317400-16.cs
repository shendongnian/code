    public void ConfigureService(IServiceCollection services)
    {
        ...
        services.AddSingleton<ISomeService, ServiceImplementation>();
    }
