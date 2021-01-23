    app.UseCors(CorsOptions.AllowAll);
    
    app.MapSignalR();
    
    AreaRegistration.RegisterAllAreas();
    GlobalConfiguration.Configure(WebApiConfig.Register);
    RouteConfig.RegisterRoutes(RouteTable.Routes);
    
    // my AutoMapper configuration
    
    // some async/await code that was calling .Wait() here. 
