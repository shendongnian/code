    private static UserPrincipal GetUser(string userName, PrincipalContext ctx)
    {
        UserPrincipal user = null;
    
        try
        {
            user = UserPrincipal.FindByIdentity(ctx, userName);
        }
        catch (Exception exc1)
        {
            Log4NetLogManager.LogError("First chance: " + exc1.Message);
        }
        userName = userName.Replace("XXX\\", string.Empty);
    
        return user ?? UserPrincipal.FindByIdentity(ctx, userName);
    }
