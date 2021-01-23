    // set up domain context using the default domain you're currently logged in 
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
        // find a user
        UserPrincipal user = UserPrincipal.FindByIdentity(ctx, Environment.UserName);
        /* or if you're interested in the *currently logged in* user,
           then you could also use:
        UserPrincipal user = UserPrincipal.Current;
        */
    
        if(user != null)
        {
            // get the "DisplayName" property ("Fullname" is WinNT specific)
            string fullName = user.DisplayName; 
            // do something here....	    
        }
    }
