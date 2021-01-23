    public class MvcApplication : HttpApplication
    {
        private static bool dbInitialized;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // We can do it asynchronously to not block other initialization code.
            Task.Run((Action)CreateDataBase);
        }
        private static void CreateDataBase()
        {
            Database.SetInitializer<PhoneDexContext>(null);
            using (PhoneDexContext db = new PhoneDexContext())
            {
                if (!db.Database.Exists())
                    db.Database.CreateIfNotExists();
            }
            dbInitialized = true;
        }
        protected void Application_BeginRequest()
        {
            if (!dbInitialized && !this.Request.Url.LocalPath.StartsWith("/Loading/LoadingScreen", StringComparison.OrdinalIgnoreCase))
            {
                this.Response.Redirect("/Loading/LoadingScreen");
            }
        }
    }
