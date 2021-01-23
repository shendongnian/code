    public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                });
            services.AddMvc();
            // authentication 
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });
            services.AddTransient(
                m => new UserManager(
                    Configuration
                        .GetValue<string>(
                            DEFAULT_CONNECTIONSTRING //this is a string constant
                            )
                    )
                );
            services.AddDistributedMemoryCache();
        }
