    public partial class Startup
    {
        private IAppBuilder _app;
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            _app = app;
            app.UseNinjectMiddleware(CreateKernel);
        }
        private IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();
            kernel.Bind<IUserStore<ApplicationUser>>().To<ApplicationUserStore>();
            kernel.Bind<ApplicationUserManager>().ToSelf();
            kernel.Bind<ApplicationSignInManager>().ToSelf();
            kernel.Bind<IAuthenticationManager>().ToMethod(x => HttpContext.Current.GetOwinContext().Authentication);
            kernel.Bind<IDataProtectionProvider>().ToMethod(x => _app.GetDataProtectionProvider());
            return kernel;
        }
    }
