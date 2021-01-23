    public partial class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // Add a new middleware validating access tokens issued by server.
            app.UseOAuthBearerAuthentication(options =>
            {
                options.AutomaticAuthentication = true;
                options.Authority = "http://localhost:50000/";
                // Audience validation is only useful if you have multiple
                // distinct resource servers (= multiple APIs).
                // See https://github.com/aspnet-contrib/AspNet.Security.OpenIdConnect.Server/issues/94#issuecomment-118360381 for more information.
                options.TokenValidationParameters.ValidateAudience = false;
            });
            // Add a new middleware issuing tokens.
            app.UseOpenIdConnectServer(options =>
            {
                options.Issuer = "http://localhost:50000/";
                options.AllowInsecureHttp = true;
                options.AuthorizationEndpointPath = PathString.Empty;
                options.Provider = new AuthorizationProvider();
                // Note: in a real world app, you'd probably prefer storing the X.509 certificate
                // in the user or machine store. To keep this sample easy to use, the certificate
                // is extracted from the Certificate.pfx file embedded in this assembly.
                options.UseCertificate(
                    assembly: typeof(Startup).Assembly,
                    resource: "ResourceOwnerPasswordFlow.Certificate.pfx",
                    password: "Owin.Security.OpenIdConnect.Server");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
