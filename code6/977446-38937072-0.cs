    Microsoft.AspNet.SignalR.GlobalHost.DependencyResolver = 
        New Microsoft.AspNet.SignalR.DefaultDependencyResolver
    app.MapSignalR(
        New Microsoft.AspNet.SignalR.HubConfiguration With
        {.Resolver = Microsoft.AspNet.SignalR.GlobalHost.DependencyResolver})
