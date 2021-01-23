    app.UseMicrosoftAccountAuthentication(new MicrosoftAccountAuthenticationOptions
    {
        ClientId = "myClientId",
        ClientSecret = "myClientSecret",
        Provider = new MicrosoftAccountAuthenticationProvider
        {
            OnAuthenticated = context =>
            {
                // here's the token
                context.Identity.AddClaim(new System.Security.Claims.Claim("AccessToken", context.AccessToken));
                context.Identity.AddClaim(new System.Security.Claims.Claim("FirstName", context.FirstName));
                context.Identity.AddClaim(new System.Security.Claims.Claim("LastName", context.LastName));
                return Task.FromResult(true);
            }
        }
    });
