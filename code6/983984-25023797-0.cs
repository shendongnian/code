    using System.DirectoryServices.AccountManagement;
    
    public UserPrincipal FindUser(string username, string domain)
    {
        var context = new PrincipalContext(ContextType.Domain, domain);
    
        var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username);
    
        // user will be null if not found
        // Remember to dispose UserPrincipal once done working with it.
        return user;
    }
