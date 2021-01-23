    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // this is the call to register your WebApi routes
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            // this is the call to register your MVC routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // register other components...
            AreaRegistration.RegisterAllAreas();    
            RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
