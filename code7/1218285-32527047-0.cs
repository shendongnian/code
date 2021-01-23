    public class MvcApplication : HttpApplication
    {
        private const String Sessionkey = "current.session";
        private static IWindsorContainer Container { get; set; }
        private static ISessionFactory SessionFactory { get; set; }
        public static ISession CurrentSession
        {
            get { return (ISession) HttpContext.Current.Items[Sessionkey]; }
            private set { HttpContext.Current.Items[Sessionkey] = value; }
        }
        protected void Application_Start()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Application["Version"] = String.Format("{0}.{1}", version.Major, version.Minor);
            Application["Name"] = ConfigurationManager.AppSettings["ApplicationName"];
            //create empty container
            //scan this assembly for any installers to register services/components with Windsor
            Container = new WindsorContainer().Install(FromAssembly.This());
            //API controllers use the dependency resolver and need to be initialized differently than the mvc controllers
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(Container.Kernel);
            //tell ASP.NET to get its controllers from Castle
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(Container.Kernel));
            //initialize NHibernate
            ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings[Environment.MachineName];
            if (connectionString == null)
                throw new ConfigurationErrorsException(String.Format("Connection string {0} is empty.",
                    Environment.MachineName));
            if (String.IsNullOrWhiteSpace(connectionString.ConnectionString))
                throw new ConfigurationErrorsException(String.Format("Connection string {0} is empty.",
                    Environment.MachineName));
            string mappingAssemblyName = ConfigurationManager.AppSettings["NHibernate.Mapping.Assembly"];
            if (String.IsNullOrWhiteSpace(mappingAssemblyName))
                throw new ConfigurationErrorsException(
                    "NHibernate.Mapping.Assembly key not set in application config file.");
            var nh = new NHInit(connectionString.ConnectionString, mappingAssemblyName);
            nh.Initialize();
             SessionFactory = nh.SessionFactory;
            AutoMapConfig.RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinderConfig.RegisterModelBinders(ModelBinders.Binders);
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
        protected void Application_OnEnd()
        {
            //dispose Castle container and all the stuff it contains
            Container.Dispose();
        }
        protected void Application_BeginRequest() { CurrentSession = SessionFactory.OpenSession(); }
        protected void Application_EndRequest()
        {
            if (CurrentSession != null)
                CurrentSession.Dispose();
        }
