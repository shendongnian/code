public class AuthCheckActionFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (!filterContext.Principal.Identity.IsAuthenticated)
            {
                HttpCookie cookie = new HttpCookie("OnAuthenticateAction");
                cookie.Value = filterContext.HttpContext.Request.Url.OriginalString;
                filterContext.HttpContext.Response.Cookies.Add(cookie);
            }
            else
            {
                if (filterContext.HttpContext.Request.Cookies.AllKeys.Contains("OnAuthenticateAction"))
                {
                    HttpCookie cookie = filterContext.HttpContext.Request.Cookies["OnAuthenticateAction"];
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    filterContext.HttpContext.Response.Cookies.Add(cookie);
                }
            }
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
