    protected void Application_Start()
    {
        //set the default scoped lifestyle
        Container container = new Container();
        container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
        ...
        //do class registration here. I did it with Scoped lifestyle
        ...
        //Let the SimpleInjector.Intergration packages register the controllers.       
        container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
        container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
        AreaRegistration.RegisterAllAreas();
        //This must be here because we first need to do above before registering the web api. See WebApiConfig code.
        GlobalConfiguration.Configure(WebApiConfig.Register);
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        
        //don't set the resolver here, do it in WebApiConfig.Register()
        //DependencyResolver.SetResolver(new SimpleInjectorWebApiDependencyResolver(container));
        DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        container.Verify(SimpleInjector.VerificationOption.VerifyAndDiagnose);
    }
