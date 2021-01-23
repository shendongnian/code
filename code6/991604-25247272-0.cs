    // set up domain context
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
        // find a user
        UserPrincipal user = UserPrincipal.FindByIdentity(ctx, "SomeUserName");
    
        if(user != null)
        {
           // do something here....	    
           txtUserName.Text = user.GivenName + ' ' + user.Surname;
           // etc.
          
        }
    }
