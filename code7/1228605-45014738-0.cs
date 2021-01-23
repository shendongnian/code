    // At Startup:
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    // ...
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        // Some middleware
        services.AddMvc();
        
        // Not-conventional "manual" bindings
        services.AddSingleton<IMySpecificService, SuperService>();
                  
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterModule(new MyConventionModule());
        containerBuilder.Populate(services);
        var autofacContainer = containerBuilder.Build();
        return autofacContainer.Resolve<IServiceProvider>();
    }
