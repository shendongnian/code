        // This method is required by Katana:
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            var config = ConfigureWebApi();
            if (DependencyResolver != null) config.DependencyResolver = CustomIocDependencyResolver(container);
            // Use the extension method provided by the WebApi.Owin library:
            app.UseWebApi(config);
        }
