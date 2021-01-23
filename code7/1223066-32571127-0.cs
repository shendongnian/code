    public static string GetFullName()
    {
       using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "yourdomain.com"))
       {
          string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
          using (UserPrincipal user = UserPrincipal.FindByIdentity(ctx, username))
          {
             if (user != null)
             {
                return user.DisplayName;
             }
          }
       }
       return null;
    }
