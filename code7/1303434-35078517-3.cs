    public void ConfigureServices(IServiceCollection services)
    {
         // Use the default role, IdentityRole as we are not implementing roles
         // Add our custom UserManager and UserStore classes
         services.AddIdentity<MyLegacyUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Cookies.ApplicationCookie.AccessDeniedPath = new Microsoft.AspNet.Http.PathString("/Auth/Login");
                config.Cookies.ApplicationCookie.LoginPath = new Microsoft.AspNet.Http.PathString("/Auth/Login");
                config.Cookies.ApplicationCookie.LogoutPath = new Microsoft.AspNet.Http.PathString("/Auth/Login");
            })
            .AddUserManager<MyLegacyUserManager>()
            .AddUserStore<MyLegacyUserUserClaimsStore>()
            .AddEntityFrameworkStores<MyDbContext>();
    } 
