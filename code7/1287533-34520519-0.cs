    public class LocalOnlyAuth : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (false == filterContext.RequestContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = 
                   new HttpStatusCodeResult(HttpStatusCode.Forbidden, "Forbidden");
            }
        }
    }
