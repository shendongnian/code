    services.Configure<IdentityOptions>(options =>
        {
            options.Password = new PasswordOptions
            {
                RequireDigit = true,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false,
                RequireLowercase = true,
                RequiredLength = 8,
            };
            options.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents
            {
                OnRedirectToLogin = ctx =>
                {
                    ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    return Task.FromResult<object>(null);
                }
            };
        });
    }
