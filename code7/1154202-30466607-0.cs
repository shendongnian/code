    protected void Application_Start()
      {
        AreaRegistration.RegisterAllAreas();
        UnityConfig.RegisterComponents();                           // <----- Add this line
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
      }  
