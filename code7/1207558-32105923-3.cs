    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var session = SessionManager.GetCurrentSession();
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var session = SessionManager.GetCurrentSession();
            session.Close();
            session.Dispose();
        }
    }
