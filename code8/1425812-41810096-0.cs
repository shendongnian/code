    services.Configure<IdentityOptions>(options =>
    {
       options.Cookies.ApplicationCookie.LoginPath = new PathString("/");
       options.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
       {
          OnRedirectToLogin = context =>
          {
             if (context.Request.Path.Value.StartsWith("/api"))
             {
                context.Response.Clear();
                context.Response.StatusCode = 401;
                return Task.FromResult(0);
             }
             context.Response.Redirect(context.RedirectUri);
             return Task.FromResult(0);
          }
       };
    });
