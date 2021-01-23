    public partial class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // Add a new middleware validating access tokens issued by the server.
            app.UseJwtBearerAuthentication(options =>
            {
                options.AutomaticAuthentication = true;
                options.Audience = "resource_server_1";
                options.Authority = "http://localhost:50000/";
                options.RequireHttpsMetadata = false;
            });
            // Add a new middleware issuing tokens.
            app.UseOpenIdConnectServer(options =>
            {
                options.AllowInsecureHttp = true;
                options.AuthorizationEndpointPath = PathString.Empty;
                options.TokenEndpointPath = "/connect/token";
                options.Provider = new AuthorizationProvider();
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
