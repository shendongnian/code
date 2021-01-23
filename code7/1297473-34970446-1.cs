    class MyServiceAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            // check the validity of the HMAC
            // return true if valid, false otherwise;
            return IsValidHMAC(WebOperationContext.Current);
        }
    }
