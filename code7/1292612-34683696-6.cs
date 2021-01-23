    services.AddIdentity<ApplicationUser, IdentityRole>(options => {
        options.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents {
            OnValidatePrincipal = options.Cookies.ApplicationCookie.Events.ValidatePrincipal,
            OnRedirectToLogin = context => {
                // When the request doesn't correspond to a static files path,
                // simply apply a 302 status code to redirect the user agent.
                if (!context.Request.Path.StartsWithSegments("/images") &&
                    !context.Request.Path.StartsWithSegments("/stylesheets")) {
                    context.Response.Redirect(context.RedirectUri);
                }
    
                return Task.FromResult(0);
            }
        };
    });
