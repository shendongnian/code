    // set up domain context
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
        // find currently logged in user
        UserPrincipal user = UserPrincipal.FindByIdentity(ctx, "palani");
    
        if(user != null)
        {
             foreach(GroupPrincipal group in user.GetAuthorizationGroups().OfType<GroupPrincipal>())
             {
                Console.WriteLine("Group name: {0}", group.Name);
             }
        }
    }
