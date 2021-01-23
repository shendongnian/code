    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        if (httpContext.Request.Headers["Authorization"] == null)
        {
            return false;
        }
        return base.AuthorizeCore(httpContext);
    }
    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
        filterContext.Result = new HttpDigestUnauthorizedResult();
    }
