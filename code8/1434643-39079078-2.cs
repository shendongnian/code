    static bool _isDbLoaded;
    public class MvcApplication : System.Web.HttpApplication
    { 
        protected void Application_Start(){
            Database.SetInitializer<PhoneDexContext>(null);
            var connString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (PhoneDexContext db = new PhoneDexContext())
            {
                if (!db.Database.Exists())
                {
                    _isDbLoaded = false;
                    db.Database.CreateIfNotExists();
                 }
             }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
       }
    }
    protected void Application_BeginRequest(){
        if(!_isDbLoaded){
            Response.Redirect("Loading/LoadingPage");
        }
    }
