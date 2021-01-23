                services.Configure<TokenAuthOptions>(options =>
            {
                options.Audience = "API";
                options.Issuer = "Web-App";
                options.SigningCredentials = new SigningCredentials(GetSigninKey(), SecurityAlgorithms.RsaSha256Signature);
                options.ExpirationDelay = TimeSpan.FromDays(365);
            });
                services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser()
                    .Build());
            }
            app.UseJwtBearerAuthentication(options =>
            {
                options.TokenValidationParameters.IssuerSigningKey = GetSigninKey();
                options.TokenValidationParameters.ValidAudience = "API";
                options.TokenValidationParameters.ValidIssuer = "Web-App";
                options.TokenValidationParameters.ValidateSignature = true;
                options.TokenValidationParameters.ValidateLifetime = true;
                options.TokenValidationParameters.ClockSkew = TimeSpan.FromMinutes(0);
            });
