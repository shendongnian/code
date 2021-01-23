    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "yourdomain.com"))
    {
        string [] newUsers; //need to declare list of new users
        foreach (string user in newUsers)
        {
           using (UserPrincipal newUser = UserPrincipal.FindByIdentity(ctx, IdentityType.UserPrincipalName, user))
           {
              if (newUser != null)
              {
                //do what you need to do
                //newUser will contain all info on a particular user
              }
           }
       }
    }
