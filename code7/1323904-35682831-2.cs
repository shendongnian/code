    public void Configuration(IAppBuilder app)
      {
        var builder = new ContainerBuilder();
    
        // STANDARD SIGNALR SETUP:
    
        // Get your HubConfiguration. In OWIN, you'll create one
        // rather than using GlobalHost.
        var config = new HubConfiguration();
    
        // Register your SignalR hubs.
        builder.RegisterHubs(Assembly.GetExecutingAssembly());
    
        // Set the dependency resolver to be Autofac.
        var container = builder.Build();
        config.Resolver = new AutofacDependencyResolver(container);
    
        // OWIN SIGNALR SETUP:
    
        // Register the Autofac middleware FIRST, then the standard SignalR middleware.
        app.UseAutofacMiddleware(container);
        app.MapSignalR("/signalr", config);
      }
