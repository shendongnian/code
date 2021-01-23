    public void Configuration(IAppBuilder appBuilder)
    {
        var config = new HttpConfiguration();
    
        config.MapHttpAttributeRoutes();
        ...
            
    }
