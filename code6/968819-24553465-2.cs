            ClaimsIdentity oAuthIdentity = await UserManager.CreateIdentityAsync(user,
            OAuthDefaults.AuthenticationType);
            AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.Id.ToString());
            oAuthIdentity.AddClaim(new Claim("TokenGuid", Guid.NewGuid().ToString()));
            var ticket = new AuthenticationTicket(oAuthIdentity, properties);
            await Startup.OAuthOptions.RefreshTokenProvider.CreateAsync(new AuthenticationTokenCreateContext(Request.GetOwinContext(), AccessTokenFormat, ticket));
            Authentication.SignIn(properties, oAuthIdentity);
