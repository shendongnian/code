    [AttributeUsage(AttributeTargets.Method)]
    internal class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override bool AuthorizeHubMethodInvocation(Microsoft.AspNet.SignalR.Hubs.IHubIncomingInvokerContext hubIncomingInvokerContext, bool appliesToMethod)
        {
            string token = hubIncomingInvokerContext.Hub.Context.Headers["AuthenticationToken"];
            if (string.IsNullOrEmpty(token))
                return false;
            else
            {
                string decryptedValue = Encryptor.Decrypt(token, Encryptor.Password);
                string[] values = decryptedValue.Split(';');
                string userName = values[0],
                    deviceId = values[1],
                    connectionId = values[2];
                bool b = ...CanAccess()...;
                return b;
            }
        }
    }
