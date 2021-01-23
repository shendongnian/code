    namespace WebApplication1
    {
        public class WebApiApplication : System.Web.HttpApplication
        {
            protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
                GlobalConfiguration.Configure(WebApiConfig.Register);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
            }
    
            void Application_PostAuthenticateRequest()
            {
                if (Request.IsAuthenticated)
                {  
                    var id = ClaimsPrincipal.Current.Identities.First();   
                }
            }
        }
    }
