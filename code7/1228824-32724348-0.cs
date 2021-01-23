    protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
    
                WebApiConfig.Register(GlobalConfiguration.Configuration);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
            }
   
     public class AdminAreaRegistration : AreaRegistration
                {
                    public override string AreaName
                    {
                        get
                        {
                            return "Admin";
                        }
                    }
            
    
                    public override void RegisterArea(AreaRegistrationContext context)
                    {
                        context.MapRoute(
                            "Admin_default",
                            "Admin/{controller}/{action}/{id}",
                            new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                        );
                    }
                }
