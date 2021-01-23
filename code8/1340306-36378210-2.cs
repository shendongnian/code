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
    
    
      3) Finally we need to inform the controller as to the binding we want it to use. This we can specify using attributes `[ModelBinder(typeof(HomeCustomBinder))]` as below:
    
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
