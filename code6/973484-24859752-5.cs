        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //code to register attribtue routes
            GlobalConfiguration.Configuration.Routes.MapHttpAttributeRoutes(config =>
            {
                config.AddRoutesFromAssembly(Assembly.GetExecutingAssembly());
            });
            //after attribute routes, now we can safely register our default routes
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
