    public class AuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            var action = operationContext.IncomingMessageHeaders.Action;
            // Fetch the operationName based on action.
            var operationName = action.Substring(action.LastIndexOf("/", StringComparison.OrdinalIgnoreCase) + 1);
            // Remove everything after ?
            int index = operationName.IndexOf("?");
            if (index > 0)
                operationName = operationName.Substring(0, index);
            return operationName.Equals("getDate", StringComparison.InvariantCultureIgnoreCase);
         }
    }
