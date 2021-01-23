    public void ConfigureServices(IServiceCollection services)
    {
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
    }
