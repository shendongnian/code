    public void ConfigureServices(IServiceCollection services)
    {
        // Choose Scope, Singleton or Transient method
        services.AddSingleton<INestedService, NestedService>(serviceProvider=>
        {
             var connectionString = Configuration["Data:ConnectionString"];
             return new NestedService(connectionString);
        });
    }
