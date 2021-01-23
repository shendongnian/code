    // This claim will be only serialized in the access token.
    identity.AddClaim(ClaimTypes.Name, username, OpenIdConnectConstants.Destinations.AccessToken);
    // This claim will be serialized in both the identity and the access tokens.
    identity.AddClaim(ClaimTypes.Surname, "Doe",
        OpenIdConnectConstants.Destinations.AccessToken,
        OpenIdConnectConstants.Destinations.IdentityToken););
