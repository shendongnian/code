        public void ConfigureServices(IServiceCollection services)
        {
            ////Grab key for signing JWT signature
            ////In prod, we'd get this from the certificate store or similar
            var certPath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "SscSign.pfx");
            var cert = new X509Certificate2(certPath);
            // configure identity server with in-memory stores, keys, clients and scopes
            services.AddDeveloperIdentityServer(options =>
                {
                    options.IssuerUri = "SomeSecureCompany";
                })
                .AddInMemoryScopes(Scopes.Get())
                .AddInMemoryClients(Clients.Get())
                .AddInMemoryUsers(Users.Get())
                .SetSigningCredential(cert);
            services.AddMvc();
        }
