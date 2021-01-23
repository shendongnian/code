    protected void Application_Start()
    {
        (new ApplicationHost()).Init();
        AreaRegistration.RegisterAllAreas();
        // Ignore ServiceStack routes
        RouteTable.Routes.IgnoreRoute("ss/{*pathInfo}");
        WebApiConfig.Register(GlobalConfiguration.Configuration);
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
