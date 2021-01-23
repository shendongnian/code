    protected void Application_Start()
    {
         AreaRegistration.RegisterAllAreas();
        
         //GlobalConfiguration.Configure(WebApiConfig.Register); // use if mvc5       
         WebApiConfig.Register(GlobalConfiguration.Configuration); // use if mvc4
         FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
