    // In the code below, "connection_string" is either the full database
    // connection string or the name of the connection string as defined
    // in the app.config or web.config files
    //
    // NOTE: This method requires a LifetimeManager. 
    // I used the default "singleton container" provided by unity.
    // This may not be appropriate for your application--please use an
    // appropriate container lifetime manager.
    container.RegisterType(typeof(IDbContext), typeof(DbContext), new ContainerControlledLifetimeManager(), new InjectionConstructor(new[] { "connection_string " }));
