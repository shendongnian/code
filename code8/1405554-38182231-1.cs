    public void ConfigureServices(IServiceCollection services)
    {
         services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 6;
                    options.User.AllowedUserNameCharacters = null;
                }).AddDefaultTokenProviders();
    }
