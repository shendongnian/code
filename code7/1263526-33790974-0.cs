      // Add Identity services to the services container.
      services.AddIdentity<ApplicationUser, IdentityRole>(options => {
            options.User.RequireUniqueEmail = false; })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
