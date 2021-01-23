    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly InterfaceReader _reader = new InterfaceReader(); // this class is doing all staff with reflection to create controller class
    
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
    
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.ServiceResolver.SetService(typeof(IHttpControllerFactory), new MyHttpControllerFactory(_reader, GlobalConfiguration.Configuration));
        }
    }
