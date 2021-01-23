    using System.DirectoryServices.AccountManagement;
    // Lock user
    using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
    {
        UserPrincipal yourUser = UserPrincipal.FindByIdentity(context, logonName);
        if (yourUser != null)
        {
            if(!yourUser.IsAccountLockedOut())
            {
                yourUser.Enabled = False;
                yourUser.Save();
            }
        }
    }
