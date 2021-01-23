    public partial class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // Add a new middleware validating access tokens issued by server.
            app.UseOAuthBearerAuthentication(options =>
            {
                options.AutomaticAuthentication = true;
                options.Audience = "http://localhost:50000/";
                options.Authority = "http://localhost:50000/";
            });
            var credentials = CreateSigningCredentials();
            // Add a new middleware issuing tokens.
            app.UseOpenIdConnectServer(options =>
            {
                options.Issuer = "http://localhost:50000/";
                options.AllowInsecureHttp = true;
                options.AuthorizationEndpointPath = PathString.Empty;
                options.SigningCredentials = credentials;
                options.Provider = new AuthorizationProvider();
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
