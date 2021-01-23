    public void ConfigureProductionServices(IServiceCollection services)
    {
        ConfigureCommonServices(services);
        
        //Services only for production
        services.Configure();
    }
    public void ConfigureDevelopmentServices(IServiceCollection services)
    {
        ConfigureCommonServices(services);
        
        //Services only for development
        services.Configure();
    }
    public void ConfigureStagingServices(IServiceCollection services)
    {
        ConfigureCommonServices(services);
        
        //Services only for staging
        services.Configure();
    }
    private void ConfigureCommonServices(IServiceCollection services)
    {
        //Services common to each environment
    }
