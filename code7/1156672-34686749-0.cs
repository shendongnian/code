    services.AddIdentity<ApplicationUser, ApplicationRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders()
        // this line is added for OpenIddict to plug in
        .AddOpenIddictCore<Application>(config => config.UseEntityFramework());
