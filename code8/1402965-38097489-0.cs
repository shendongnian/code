    static bool isAdmin(string username, string machinename)
    {
    using (PrincipalContext ctxMacine = new PrincipalContext(ContextType.Machine, machinename))
    {
        using (PrincipalContext ctxDomain = new PrincipalContext(ContextType.Domain))
        {
            UserPrincipal up = UserPrincipal.FindByIdentity(ctxDomain, IdentityType.SamAccountName, username);
            GroupPrincipal gp = GroupPrincipal.FindByIdentity(ctxMacine, "Administrators");
            foreach (UserPrincipal usr in gp.GetMembers(true))
            {
                if (up != null)
                {
                    if (up.SamAccountName.ToUpper() == usr.SamAccountName.ToUpper())
                    {
                        return true;
                    }
                }
            }
        }
    }
    return false;
