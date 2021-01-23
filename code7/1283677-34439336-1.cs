                app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                    AllowedAudiences = new List<string>() { JWTConfigs.audience },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new CustomSymmetricKeyIssuerSecurityTokenProvider(JWTConfigs.issuer, key)
                    },
                    TokenHandler = new CustomJWTTokenHandler()
                }
            );
