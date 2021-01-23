    public class FunctionalityAttribute : AuthorizeAttribute
    {
        public string FunctionalityName { get; set; }
    
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string adGroup = WebConfigurationManager.AppSettings[FunctionalityName];
    
            if (actionContext.RequestContext.Principal.IsInRole(adGroup)) { return true; }
    
            return false;
        }
    
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            // Authenticated, but not authorized.
            if (actionContext.RequestContext.Principal.Identity.IsAuthenticated)
            {
                // Use Forbidden because Unauthorized causes a login prompt to display.
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
        }
    }
