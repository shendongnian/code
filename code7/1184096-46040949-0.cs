         public class HomeController : Controller
            {
                public string _MyName { get; set; }
                // GET: Home
                public ActionResult Index()
                {
                    return Content(_MyName);
                }
        
                public HomeController(string Name)
                {
                    _MyName = Name;
                }
            }
    
    
     public class MyCustomController : IControllerFactory
        {
            public IController CreateController(RequestContext requestContext, string controllerName)
            {
                HomeController objHomeController = new HomeController("Any thing Which you want to pass/inject.");
                return objHomeController;
            }
    
            public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
            {
                return SessionStateBehavior.Default;
            }
    
            public void ReleaseController(IController controller)
            {
                IDisposable disposable = controller as IDisposable;
                if(disposable!=null)
                {
                    disposable.Dispose();
                }
            }
        }
    
    
    
     protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                ControllerBuilder.Current.SetControllerFactory(new MyCustomController());
            }
