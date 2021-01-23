     app.UseCookieAuthentication(options =>
            {
                options.AutomaticAuthentication = true;
            });
            app.Run(async context =>
            {
                if (string.IsNullOrEmpty(context.User.Identity.Name))
                {
                    var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "bob") }));
                           context.Authentication.SignIn(CookieAuthenticationDefaults.AuthenticationScheme, user);
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Hello First timer");
                    return;
                }
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Hello old timer");
            });
