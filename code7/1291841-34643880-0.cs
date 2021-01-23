    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
        // find a user
        UserPrincipal user = UserPrincipal.FindByIdentity(ctx, "SomeDomainUserName");
    
        if(user != null)
        {
           // get the user's groups
           var groups = user.GetAuthorizationGroups();
           foreach(GroupPrincipal group in groups)
           {
               //do what you need to do with those groups
           }
        }
    }
