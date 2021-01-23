    public partial class Startup
    {
        /// <summary>
        ///     Used to create an instance of the Web application
        /// </summary>
        /// <param name="app">Parameter supplied by OWIN implementation which our configuration is connected to</param>
        public void Configuration(IAppBuilder app)
        {
            // Wire-in the authentication middleware
            ConfigureAuth(app);
            // In OWIN you create your own HttpConfiguration rather than re-using the GlobalConfiguration.
            HttpConfiguration config = new HttpConfiguration();
            // Handle registration of Swagger API docs
            SwaggerConfig.Register(config);
            // Handles registration of the Web API's routes
            WebApiConfig.Register(config);
            // Register web api
            app.UseWebApi(config);
        }
