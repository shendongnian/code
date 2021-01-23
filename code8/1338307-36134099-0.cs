    protected override Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested(); 
        if (userName != "testuser" || password != "Pass1word")
        {
            // No user with userName/password exists.
            return null;
        }
        Claim nameClaim = new Claim(ClaimTypes.Name, userName);
        List claims = new List { nameClaim };
        ClaimsIdentity identity = new ClaimsIdentity(claims, AuthenticationTypes.Basic);
        var principal = new ClaimsPrincipal(identity);
        return principal;
    }
