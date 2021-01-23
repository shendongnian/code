    public void ConfigureServices(IServiceCollection services) {
        services.AddMvc();
        services.AddScoped<ISessionService, SessionService>();
        services.AddScoped<EnsureUserLoggedIn>();
        
        ...
    }
