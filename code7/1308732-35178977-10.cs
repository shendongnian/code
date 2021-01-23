    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Register them in this order
            GlobalConfiguration.Configure(WebApiConfig.Configure); //registers WebApi routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);  //register MVC routes
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
