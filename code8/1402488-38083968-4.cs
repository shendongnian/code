    protected void Application_Start()
    {
        // Pass a delegate to the Configure method.
        GlobalConfiguration.Configure(WebApiConfig.Register);
        ///MVC Routes
        RouteConfig.RegisterRoutes(RouteTable.Routes);
    }
