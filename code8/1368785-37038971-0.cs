    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        private bool AuthorizeUser(AuthorizationContext filterContext)
        {
            bool isAuthorized = false;
    
            if (filterContext.RequestContext.HttpContext != null)
            {
                var context = filterContext.RequestContext.HttpContext;
    
                if (context.Session["AuthID"] != null &&
                    context.Request.Cookies["AuthID"].Values["AuthID"] ==
                    context.Session["AuthID"].ToString())
                {
                    isAuthorized = true;
                }
            }
            return isAuthorized;
        }
    
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");
    
            if (AuthorizeUser(filterContext))
                return;
    
            base.OnAuthorization(filterContext);
        }
    }
