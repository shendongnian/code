    class UpeWrapper : IDisposable
    {
      public readonly PrincipalContext PrincipalContext;
      public readonly UserPrincipalExtension UserPrincipalExtension;
      public UpeWrapper(PrincipalContext principalContext, 
                        UserPrincipalExtension userPrincipalExtension)
      {
        this.PrincipalContext = principalContext;
        this.UserPrincipalExtension = userPrincipalExtension;
      }
      public void Dispose()
      {
        try
        {
          UserPrincipalExtension.Dispose();
        }
        finally
        {
          PrincipalContext.Dispose();
        }
      }
    }
