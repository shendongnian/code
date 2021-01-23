            //setup office 365
            var office365Options = new Office365AuthenticationOptions
            {
                ClientId = ConfigurationManager.AppSettings["ada:ClientId"],
                ClientSecret = ConfigurationManager.AppSettings["ada:ClientSecret"],
                Provider = new Office365AuthenticationProvider
                {
                    OnAuthenticated = async context =>
                    {
                        await
                            Task.Run(
                                () => context.Identity.AddClaim(new Claim("Office365AccessToken", context.AccessToken)));
                    }
                },
                SignInAsAuthenticationType = DefaultAuthenticationTypes.ExternalCookie
            };
           
            office365Options.Scope.Add("offline_access");
            app.UseOffice365Authentication(office365Options);
