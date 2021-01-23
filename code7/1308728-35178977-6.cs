    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Configure); //registers WebApi routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);  //register MVC routes
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
