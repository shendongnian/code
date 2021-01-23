        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            HttpConfiguration config = GlobalConfiguration.Configuration;
            app.UseWebApi(config);
        }
