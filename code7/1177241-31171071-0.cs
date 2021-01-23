    // set up domain context
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
        // find a user
        UserPrincipal user = UserPrincipal.FindByIdentity(ctx, username);
    
        if(user != null)
        {
           // do something here....
           // the most often used attributes are available as nice, strongly-typed properties
           string value = user.GivenName;
           value = user.Surname;
           value = user.EmailAddress;
           value = user.VoiceTelephoneNumber;
        }
    }
