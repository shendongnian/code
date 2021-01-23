    public class AjaxOnlyAuthorization : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                //..No Go
            }
        }
    }
