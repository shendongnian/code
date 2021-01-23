    public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                AreaRegistration.RegisterAllAreas();
                GlobalConfiguration.Configure(WebApiConfig.Register);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                 RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                   this._account.ConfigureAuth(app);
    
                app.UseNinjectMiddleware(CreateKernel);
                app.UseNinjectWebApi(config);
            }
        }
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
    
            kernel.Bind<IAccountService>().To<AccountService>();
            return kernel;
        }
