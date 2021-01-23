    private async Task SignIn(string username)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username)
        };
        // TODO: get roles from external source
        claims.Add(new Claim(ClaimTypes.Role, "Admin"));
        claims.Add(new Claim(ClaimTypes.Role, "Moderator"));
        var identity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme,
            ClaimTypes.Name,
            ClaimTypes.Role
        );
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity),
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMonths(1)
            }
        );
    }
