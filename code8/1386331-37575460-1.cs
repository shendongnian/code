    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
			// Decorate the current dependency resolver 
			// (make sure to do this last if using a DI container - 
            // or alternatively register your type with the DI container)
            DependencyResolver.SetResolver(
				new DependencyResolverForControllerActionInvoker(DependencyResolver.Current));
        }
    }
