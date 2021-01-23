    List<AppServiceIdentity> identities = null;
    
    public async Task<AppServiceIdentity> GetIdentityAsync()
    {
        if (client.CurrentUser == null || client.CurrentUser?.MobileServiceAuthenticationToken == null)
        {
            throw new InvalidOperationException("Not Authenticated");
        }
    
        if (identities == null)
        {
            identities = await client.InvokeApiAsync<List<AppServiceIdentity>>("/.auth/me");
        }
    
        if (identities.Count > 0)
            return identities[0];
        return null;
    }
