    private Principal GetUserPrincipal(PrincipalContext context, string name)
    {
        var nta = new NTAccount(name);
        try
        {
            var sid = nta.Translate(typeof(SecurityIdentifier)).Value;
            return Principal.FindByIdentity(context, IdentityType.Sid, sid);
        }
        catch (IdentityNotMappedException)
        {
            return null;
        }
    }
