    public class YourAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var ticket = Startup.OAuthOptions.AccessTokenFormat.Unprotect(actionContext.Request.Headers.Authorization.Parameter);
            string username = claims.Where(x => x.Type == "username").FirstOrDefault();
            base.OnAuthorization(actionContext);
        }
    }
