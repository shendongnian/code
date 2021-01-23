    public class BasicAuthMessageHandler : DelegatingHandler
    {
        private const string ResponseHeader = "WWW-Authenticate";
        private const string ResponseHeaderValue = "Basic";
     
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            AuthenticationHeaderValue authValue = request.Headers.Authorization;
            if (authValue != null && !String.IsNullOrWhiteSpace(authValue.Parameter))
            {
                Credentials parsedCredentials = ParseAuthorizationHeader(authValue.Parameter);
                if (parsedCredentials != null)
                {
                    //Here check the provided credentials against your custom user store
                    if(parsedCredentials.Username == "Username" && parsedCredentials.Password == "Pass") 
                    {
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(parsedCredentials.Username), null);
                    }
                }
            }
            return base.SendAsync(request, cancellationToken)
               .ContinueWith(task =>
               {
                   var response = task.Result;
                   if (response.StatusCode == HttpStatusCode.Unauthorized
                       && !response.Headers.Contains(ResponseHeader))
                   {
                       response.Headers.Add(ResponseHeader, ResponseHeaderValue);
                   }
                   return response;
               });
        }
     
        private Credentials ParseAuthorizationHeader(string authHeader)
        {
            string[] credentials = Encoding.ASCII.GetString(Convert
                                                            .FromBase64String(authHeader))
                                                            .Split(
                                                            new[] { ':' });
            return new Credentials()
                       {
                           Username = credentials[0],
                           Password = credentials[1],
                       };
        }
    }
    public class Credentials
    {
        public string Username {get;set;}
        public string Password {get;set;}
    }
