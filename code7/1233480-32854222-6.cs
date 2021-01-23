    public class MvcApplication : System.Web.HttpApplication
    {
		// This method serves as the composition root
		// for the project.
        protected void Application_Start()
		{
			// Register Autofac DI
			IContainer container = ContainerConfig.RegisterContainer();
		
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, container);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }
