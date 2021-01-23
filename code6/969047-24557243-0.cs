    // set up domain context
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
        // find a user
        UserPrincipal user = UserPrincipal.FindByIdentity(ctx, "SomeUserName");
    
        if(user != null)
        {
           // do something here....	    
        }
        // add a new user
        UserPrincipal newUser = new UserPrincipal(ctx);
        // set properties
        newUser.givenName = "....";
        newUser.surname = "....";
        .....
 
        // save new user
        newUser.Save();
    }
