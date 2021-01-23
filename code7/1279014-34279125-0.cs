        public void Configuration( IAppBuilder app )
        {
            var config = new HttpConfiguration();
            config.DependencyResolver = new NinjectResolver( new Ninject.Web.Common.Bootstrapper().Kernel );
            WebApiConfig.Register( config );
            app.UseWebApi( config );
        }
