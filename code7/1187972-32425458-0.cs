    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        GlobalConfiguration.Configure(WebApiConfig.Register);
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        // CODE FIRST MIGRATIONS
        #if !DEBUG
           var migrator = new DbMigrator(new Configuration());
           migrator.Update();
        #endif
    }
    
