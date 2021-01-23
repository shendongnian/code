    public void ConfigureAuth(IAppBuilder app)
            {
                app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                    new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                    {
                        Tenant = ConfigurationManager.AppSettings["ida:Tenant"],
                        TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidAudience = ConfigurationManager.AppSettings    ["ida:Audience"]
                        }
                    });
            }
