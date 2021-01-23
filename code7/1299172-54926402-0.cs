        public void ConfigureServices(IServiceCollection services)
        {
                services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.SameSite = SameSiteMode.Strict;
                    options.Cookie.Name = "AuthCookie";
                    options.Events.OnRedirectToAccessDenied = UnAuthorizedResponse;
                    options.Events.OnRedirectToLogin = UnAuthorizedResponse;
                })
        ....
        }
        internal static Task UnAuthorizedResponse(RedirectContext<CookieAuthenticationOptions> context)
        {
            context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
            return Task.CompletedTask;
        }
