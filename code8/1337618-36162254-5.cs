    var identity = new ClaimsIdentity(new[] {
        new Claim(ClaimTypes.Email, "users email"),
        // other business specific claims e.g. "IsAdmin"
    });
    var ticket = new AuthenticationTicket(identity, new AuthenticationProperties(
        {
            ExpiresUtc = DateTime.UtcNow.AddMinutes(10)
        }));
    var accessToken = MyProject.Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);
