    // REGISTER CONTROLLERS SO DEPENDENCIES ARE CONSTRUCTOR INJECTED
    builder.RegisterControllers(typeof(MvcApplication).Assembly);
    builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
    // Register the SignalR hubs.
    builder.RegisterType<UpdateHub>().ExternallyOwned();
    builder.RegisterType<NotificationHub>().ExternallyOwned();
    
    // BUILD THE CONTAINER
    var container = builder.Build();
    // Configure SignalR with an instance of the Autofac dependency resolver.
    GlobalHost.DependencyResolver = new Autofac.Integration.SignalR.AutofacDependencyResolver(container);
    DependencyResolver.SetResolver(new Autofac.Integration.Mvc.AutofacDependencyResolver(container));
    GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
    // REGISTER WITH OWIN
    app.UseAutofacMiddleware(container);
    app.UseAutofacMvc();
    app.MapSignalR();
    ConfigureAuth(app);
