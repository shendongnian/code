    var tokenExpiration = TimeSpan.FromMinutes(30);
    ClaimsIdentity identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
    identity.AddClaim(new Claim(ClaimTypes.Name, userName));
    identity.AddClaim(new Claim("role", "user"));
    var props = new AuthenticationProperties()
    {
        IssuedUtc = DateTime.UtcNow,
        ExpiresUtc = DateTime.UtcNow.Add(tokenExpiration),
    };
    var ticket = new AuthenticationTicket(identity, props);
    var accessToken = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);
