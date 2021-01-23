    public class TokenAuthenticationAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            // Do your authentication here
        }
    
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext", "Null actionContext");
            }
    
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("AuthenticationStatus", "NotAuthorized");
            actionContext.Response.ReasonPhrase = "Authentication failed";
        }
    }
