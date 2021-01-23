    services.AddIdentity<User, Role>(identityOptions =>
        {
            identityOptions.Cookies.ApplicationCookie.Events =
                new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = context =>
                                        {
                                            if (context.Request.Path.StartsWithSegments("/api") &&
                                                context.Response.StatusCode == (int) HttpStatusCode.OK)
                                                context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                                            else
                                                context.Response.Redirect(context.RedirectUri);
                                            return Task.CompletedTask;
                                        }
                };
        });
