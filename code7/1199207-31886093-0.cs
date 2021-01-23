       // global asax
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
           // ... more stuff
        }
       //startup.cs
       public void Configuration(IAppBuilder app)
        {
            // This must happen FIRST otherwise CORS will not work.
            app.UseCors(CorsOptions.AllowAll);
            HttpConfiguration config = new HttpConfiguration();
            
            ConfigureAuth(app);
            // webapi is registered in the global.asax
            app.UseWebApi(config);
        }
