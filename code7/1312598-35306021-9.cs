    public void ConfigureServices(IServiceCollection services)
    {
        //...
        //identity server 4 cert
        var cert = new X509Certificate2(Path.Combine(_environment.ContentRootPath, "idsrv4test.pfx"), "your_cert_password");
        //DI DBContext inject connection string
            services.AddScoped(_ => new YourDbContext(Configuration.GetConnectionString("DefaultConnection")));
    
        //my user repository
        services.AddScoped<IUserRepository, UserRepository>();
        //add identity server 4
        services.AddIdentityServer()
            .AddSigningCredential(cert)
            .AddInMemoryIdentityResources(Config.GetIdentityResources()) //check below
            .AddInMemoryApiResources(Config.GetApiResources())
            .AddInMemoryClients(Config.GetClients())
            .AddProfileService<ProfileService>();
        //Inject the classes we just created
        services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
        services.AddTransient<IProfileService, ProfileService>();
        //...
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        //...
        app.UseIdentityServer();
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        IdentityServerAuthenticationOptions identityServerValidationOptions = new IdentityServerAuthenticationOptions
        {
            //move host url into appsettings.json
            Authority = "http://localhost:50000/",
            //AllowedScopes = new List<string> { "dataEventRecords" },
            ApiSecret = "secret",
            ApiName = "my.api.resource",
            AutomaticAuthenticate = true,
            SupportedTokens = SupportedTokens.Both,
            // required if you want to return a 403 and not a 401 for forbidden responses
            AutomaticChallenge = true,
            //change this to true for SLL
            RequireHttpsMetadata = false
        };
 
        app.UseIdentityServerAuthentication(identityServerValidationOptions);
        //...
    }
