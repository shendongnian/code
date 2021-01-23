    public void Configuration(IAppBuilder appBuilder)
    {
        var config = new HttpConfiguration();
        
        //I use attribute-based routing for ApiControllers
        config.MapHttpAttributeRoutes(); 
    
        appBuilder.Map("/signalr", map =>
        {
            var hubConfiguration = new HubConfiguration
            {
    
            };
    
            map.RunSignalR(hubConfiguration);
        });
    
        config.EnsureInitialized(); //Nice to check for issues before first request
    
        appBuilder.UseWebApi(config);
    }
