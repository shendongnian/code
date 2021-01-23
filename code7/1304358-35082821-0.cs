    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            // Get your HttpConfiguration. In OWIN, you'll create one
            // rather than using GlobalConfiguration.
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            // Register your Web Api controllers.
            IoC.Instance.RegisterApiControllers(Assembly.GetExecutingAssembly());
            IoC.Instance.RegisterWebApiModelBinders(Assembly.GetExecutingAssembly());
            IoC.Instance.RegisterWebApiModelBinderProvider();
     
            config.DependencyResolver =
            new AutofacWebApiDependencyResolver(IoC.Instance.GetComponentsContainer());
            // Register your Web Api controllers.
            //IoC.Instance.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //IoC.Instance.RegisterWebApiModelBinders(Assembly.GetExecutingAssembly());
            //IoC.Instance.RegisterWebApiModelBinderProvider();
     
            // Register the Autofac middleware FIRST, then the Autofac Web API middleware,
            // and finally the standard Web API middleware.
            app.UseAutofacMiddleware(IoC.Instance.GetComponentsContainer());
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
          
        }
    }
