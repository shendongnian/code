    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    
        services.AddAuthorization();
    
        services.AddSingleton<IAuthorizationHandler,
                              AccountAuthorizationHandler>();
    }
