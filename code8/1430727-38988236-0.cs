    public bool IsUserLocked (string username)
    {
       using(PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "yourdomain.com")
        {
           using (UserPrincipal user = UserPrincipal.FindByIdentity(ctx, username)
           {
              if (user != null) return user.IsAccountLockedOut();
           }
        }
        return null;
    }
