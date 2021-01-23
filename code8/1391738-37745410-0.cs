    public void ConfigureServices(IServiceCollection services)
    {
        // Choose Scope, Singleton or Transient method
        services.AddSingleton<IRootService, RootService>();
        services.AddSingleton<INestedService, NestedService>(serviceProvider=>
        {
             return new NestedService("someConnectionString");
        });
    }
