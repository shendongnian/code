    public async Task<AuthenticateResult> AuthenticateAsync(string authenticationType)
    {
        return (await AuthenticateAsync(new[] { authenticationType })).SingleOrDefault();
    }
    public async Task<IEnumerable<AuthenticateResult>> AuthenticateAsync(string[] authenticationTypes)
    {
        var results = new List<AuthenticateResult>();
        await Authenticate(authenticationTypes, AuthenticateAsyncCallback, results);
        return results;
    }
