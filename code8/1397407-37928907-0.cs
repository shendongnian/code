    ...
    string UserName = "yourUserName";
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "yourdomain.com")
    {
       using (UserPrincipal user = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, userName)
       if (user != null)
       {
          //user will contain information such as name, email, phone etc..
       }
    }
