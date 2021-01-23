    Please make sure you have done something like this:-
    1)
    
     - **Custom Model Binding:-**
    
    public class HomeCustomDataBinder : DefaultModelBinder
        {
    
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                if (bindingContext.ModelType == typeof(HomePageModels))
                {
                    HttpRequestBase request = controllerContext.HttpContext.Request;
    
                    string title = request.Form.Get("Title");
                    string day = request.Form.Get("Day");
                    string month = request.Form.Get("Month");
                    string year = request.Form.Get("Year");
    
                    return new HomePageModels
                    {
                        Title = title,
                        Date = day + "/" + month + "/" + year
                    };
    
                    //// call the default model binder this new binding context
                    //return base.BindModel(controllerContext, newBindingContext);
                }
                else
                {
                    return base.BindModel(controllerContext, bindingContext);
                }
            }
    
        } 
    
    2) Once we have completed coding our custom class we will need to register the class which I do in the Global.asax under Application_Start().
    
    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        WebApiConfig.Register(GlobalConfiguration.Configuration);
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        AuthConfig.RegisterAuth();
        ModelBinders.Binders.Add(typeof(HomePageModels), new HomeCustomBinder());
    }
    
    3) Finally we need to inform the controller as to the binding we want it to use. This we can specify using attributes [ModelBinder(typeof(HomeCustomBinder))] as below:
    
    
    [HttpPost]
    public ActionResult Index([ModelBinder(typeof(HomeCustomBinder))] HomePageModels home)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Title = home.Title;
            ViewBag.Date = home.Date;
        }
        return View();
    }
