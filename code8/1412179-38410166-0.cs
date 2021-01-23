    public enum AuthTokenType
    {
        OAuth2Bearer,
        Custom
    }
    public class CustomAuthenticationAttribute : IAuthenticationFilter
    {
        public bool AllowMultiple
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
                HttpRequestMessage incommingRequest = context.Request;
                string authHeader = incommingRequest.Headers["Authorization"];
                AuthTokenType authTokenType = DetecteAuthTokenType(authHeader);
                
                if (authTokenType == AuthTokenType.OAuth2Bearer) 
                {
                   // Validate auth token using the JwtSecurityTokenHandler class
                }
                else if (authTokenType == AuthTokenType.Custom)
                {
                   // Validate auth token using whatever is necessary
                }
                else
                {
                   // auth token doesn't correspond to a recognized type or hasn't been part of the client request - reject request
                }  
        }
        public AuthTokenType DetectAuthTokenType(string authHeader)
        {
           // Analyze the authorization header string and return its proper type
        }
    }
