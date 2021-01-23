    [assembly: OwinStartup(typeof(Startup))]
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            var container = new UnityContainer();
            UnityConfig.RegisterComponents(container);
            config.DependencyResolver = new UnityDependencyResolver(container);
            //config.DependencyResolver = new UnityHierarchicalDependencyResolver(container);
            WebApiConfig.Register(config);
            ConfigureOAuth(app);
            app.UseWebApi(config);
        }
        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };
            // Token Generation
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
        }
    }
