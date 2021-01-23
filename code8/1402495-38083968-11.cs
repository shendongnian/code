    public void Configuration(IAppBuilder app)
    {
        LoggingConfig.ConfigureLogger();
        HttpConfiguration httpConfiguration = GlobalConfiguration.Configuration;
        GlobalConfiguration.Configure(WebApiConfig.Register);
        var container = IoC.Initialize();
        httpConfiguration.DependencyResolver = new StructureMapResolver(container);
        ConfigAuth(app);       
        app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);        
        Log.Logger.ForContext<Startup>().Information("======= Starting Owin Application ======");
    }
