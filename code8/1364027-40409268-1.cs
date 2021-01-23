    public class AutoRedirectFilter : ActionFilterAttribute, IAuthenticationFilter
    {
       
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if(filterContext.Principal.Identity.IsAuthenticated)
            {       
                if(filterContext.HttpContext.Request.Cookies.AllKeys.Contains("OnAuthenticateAction"))
                {
                    HttpCookie cookie = filterContext.HttpContext.Request.Cookies["OnAuthenticateAction"];
                    filterContext.HttpContext.Response.Redirect(cookie.Value);
                }
            }
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
