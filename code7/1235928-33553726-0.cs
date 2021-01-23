    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
       // Add MVC services to the services container.
       services.AddMvc();
       // Create the autofac container
       var builder = new ContainerBuilder();
       // Create the container and use the default application services as a fallback
       //AutofacRegistration.Populate(builder, services);
       // Populate the services.
       builder.Populate(services);
       // Add any Autofac modules or registrations.
       builder.RegisterModule(new AutofacModule());
       Container = builder.Build();
       // Resolve and return the service provider.
       return Container.Resolve<IServiceProvider>();
    }
