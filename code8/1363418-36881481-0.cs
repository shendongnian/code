        var authority = string.Format("{0}/{1}", ServiceConstants.AzureADEndPoint, "common");
        var options = new OpenIdConnectAuthenticationOptions {
            ClientId = OAuthSettings.ClientId,
            Authority = authority,
            TokenValidationParameters = new System.IdentityModel.Tokens.TokenValidationParameters {
                ValidateIssuer = false
            }
        };
