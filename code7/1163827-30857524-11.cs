    public partial class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            var certificate = LoadCertificate();
            var key = new X509SecurityKey(certificate);
            var credentials = new SigningCredentials(key,
                SecurityAlgorithms.RsaSha256Signature,
                SecurityAlgorithms.Sha256Digest);
            // Add a new middleware validating access tokens issued by the server.
            app.UseOAuthBearerAuthentication(options =>
            {
                options.AutomaticAuthentication = true;
                options.Audience = "http://localhost:50000/";
                options.Authority = "http://localhost:50000/";
            });
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
