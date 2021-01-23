    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterWebApiFilters(System.Web.Http.Filters.HttpFilterCollection filters)
        {
            filters.Add(new HandleExceptionAttribute());
        }
    
        protected void Application_Start()
        {
             RegisterWebApiFilters(GlobalConfiguration.Configuration.Filters);
        }
    }
