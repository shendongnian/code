        public void ConfigureServices(IServiceCollection services)
        {
        //...
    #if DEBUG
        services.AddTransient<IAuthorizationHandler, DisableAuthorizationHandler<IAuthorizationRequirement>>();
    #endif
        //...
        }
