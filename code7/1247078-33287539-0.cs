    public class RestAuthorizationManager: ServiceAuthorizationManager  
    {  
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            //Extract the Authorization header, and parse out the credentials converting the Base64 string:
            var authHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
            if ((authHeader != null) && (authHeader != string.Empty))
            {
                var svcCredentials = System.Text.ASCIIEncoding.ASCII
                        .GetString(Convert.FromBase64String(authHeader.Substring(6)))
                        .Split(':');
                var user = new { Name = svcCredentials[0], Password = svcCredentials[1] };
                if ((user.Name == "user1" && user.Password == "test"))
                {
                    //User is authrized and originating call will proceed
                    return true;
                }
                else
                {
                    //not authorized
                    return false;
                }
            }
            else
            {
                //No authorization header was provided, so challenge the client to provide before proceeding:
                WebOperationContext.Current.OutgoingResponse.Headers.Add("WWW-Authenticate: Basic realm=\"MyWCFService\"");
                //Throw an exception with the associated HTTP status code equivalent to HTTP status 401
                throw new WebFaultException("Please provide a username and password", HttpStatusCode.Unauthorized);
            }
        }
    }
