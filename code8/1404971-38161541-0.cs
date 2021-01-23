        /// Configures cookie auth for web apps and JWT for SPA,Mobile apps
        private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            // Configure the db context, user manager and role manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            //Cookie for old school MVC application
            var cookieOptions = new CookieAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                CookieHttpOnly = true, // JavaScript should use the Bearer
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,                
                LoginPath = new PathString("/api/Account/Login"),
                CookieName = "AuthCookie"
            };
            // Plugin the OAuth bearer JSON Web Token tokens generation and Consumption will be here
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            
            OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(30),
                Provider = new CustomOAuthProvider(),                
                AccessTokenFormat = new CustomJwtFormat(ConfigurationManager.AppSettings["JWTPath"])
            };
            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
       }
	   
