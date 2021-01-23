    public class Authorize2 : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // 1. Get the default login url that was declared in web.config
            string returnUrl = FormsAuthentication.LoginUrl;
            // 2. Append current url as a return url to the login url
            returnUrl += "?ReturnUrl=" + HttpUtility.UrlEncode(HttpContext.Current.Request.Url.PathAndQuery);
            // 3. ...
            // 4. Profit
            filterContext.Result = new RedirectResult(returnUrl);
        }
    }
