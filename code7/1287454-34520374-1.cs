    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
        var form = await context.Request.ReadFormAsync();
    
        if (string.Equals(form["remember"], "true", StringComparison.OrdinalIgnoreCase))
        {
            // Add custom logic to handle the "remember me" case.
        }
    }
