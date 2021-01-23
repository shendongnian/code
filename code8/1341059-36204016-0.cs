    namespace MyApp
    {
     
        public class WebApplication : System.Web.HttpApplication
        {
            public static void RegisterGlobalFilters(GlobalFilterCollection filters)
            {
                filters.Add(new HandleErrorAttribute());
            }
    
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");    
                routes.MapRoute(
                    "Notification", // Route name
                    "{controller}/{action}", // URL with parameters
                    new { controller = "Notification", action = "Index" } // Parameter defaults
                );
            }    
            protected void Application_Start()
            {
                //Web api config
                GlobalConfiguration.Configure(WebApiConfig.Register);
                //MVC config
                AreaRegistration.RegisterAllAreas();    
                RegisterGlobalFilters(GlobalFilters.Filters);
                RegisterRoutes(RouteTable.Routes);
            }
        }
    }
