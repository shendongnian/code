    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Configure); //registers WebApi routes
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);  //register MVC routes
            BackgroundConfig.Configure();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
