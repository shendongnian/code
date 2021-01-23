    public class CustomAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                if(UserClaims.PersonId == 0)
                {
                    UrlHelper helper = new UrlHelper(filterContext.RequestContext);
                    
                    string url = helper.Action("Unauthorized","Error",null,filterContext.HttpContext.Request.Url.Scheme);
                    filterContext.Result = new RedirectResult(url);
                }
            }
        }
    }
