    public AuthorizationValidator : IAuthorizationValidator
    {
      public AuthorizationValidator(IDataAccess dataAccess, IPrincipalFactory principalFactory)
      {
         // Save injected objects
         _dataAccess = dataAccess;
         _principal = principalFactory.GetCurrentPrincipal();
      }
      public bool CheckPermission(Guid objectId, Action action)
      {
         // Same as previous example
         ...
      }
    }
    public interface IPrincipalFactory
    {
      IPrincipal GetCurrentPrincipal();
    }
