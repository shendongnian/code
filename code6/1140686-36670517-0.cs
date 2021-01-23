    public void ConfigureServices(IServiceCollection services)
    {        
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddMvcCore();
    }
