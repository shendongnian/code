    protected override Task<TUser> InstantiateNewUserFromExternalProviderAsync(
        string provider,
        string providerId,
        IEnumerable<Claim> claims)
    {
        var user = new TUser
        {
            UserName = Guid.NewGuid().ToString("N"),
            Claims = claims
        };
        return Task.FromResult(user);
    }
