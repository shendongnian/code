     app.UseFacebookAuthentication(new FacebookAuthenticationOptions
                {
                    AppId = "XXXXXXXXXX",
                    AppSecret = "XXXXXXXXXX",
                    Scope = { "email" },
                    Provider = new FacebookAuthenticationProvider
                    {
                        OnAuthenticated = context =>
                        {
                            context.Identity.AddClaim(new System.Security.Claims.Claim("FacebookAccessToken", context.AccessToken));
                            return Task.FromResult(true);
                        }
                    }
                });
