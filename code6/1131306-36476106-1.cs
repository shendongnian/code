    // SignalR Configuration
    var signalRConfig = new HubConfiguration();
    
    var builder = // Create your normal AutoFac container here
    builder.RegisterType<MyHub>().ExternallyOwned(); // SignalR hub registration
    
    // Register the Hub for DI (THIS IS THE MAGIC LINE)
    builder.Register(i => signalRConfig.Resolver.Resolve<IConnectionManager>().GetHubContext<MyHub, IMyHub>()).ExternallyOwned();
                    
    // Build the container
    var container = builder.Build();
    
    // SignalR Dependency Resolver
    signalRConfig.Resolver = new Autofac.Integration.SignalR.AutofacDependencyResolver(container);
    app.UseAutofacMiddleware(container);
    app.MapSignalR("/signalr", signalRConfig);
