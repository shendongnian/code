    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        // add other framework services
    
        // Add Autofac
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterModule<DefaultModule>();
        containerBuilder.Populate(services);
        var container = containerBuilder.Build();
        return container.Resolve<IServiceProvider>();
    }
