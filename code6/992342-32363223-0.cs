               new OpenIdConnectAuthenticationOptions
                {
                    ...,
                    TokenValidationParameters = new System.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = false
                    },
