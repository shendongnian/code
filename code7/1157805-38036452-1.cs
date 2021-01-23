    public void Configuration(IAppBuilder app)
        {            
            ConfigureAuth(app);
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("ConnectString");
            
            GlobalConfiguration.Configuration.UseNinjectActivator(new Ninject.Web.Common.Bootstrapper().Kernel);
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
