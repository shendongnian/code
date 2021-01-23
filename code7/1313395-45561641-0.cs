    app.Map("/hubUrl", map =>
    {
         var hubConfiguration = new HubConfiguration
                    {
                        EnableJavaScriptProxies = false,
                        Resolver = InitializeNinjectDepenedencyResolver()
                    };
         GlobalHost.DependencyResolver = hubConfiguration.Resolver;
         map.RunSignalR(hubConfiguration);
    }
