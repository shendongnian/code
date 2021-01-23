    private bool Authorize(AuthorizationContext actionContext)
    {
        try
        {
            HttpContextBase context = actionContext.RequestContext.HttpContext;
            string token = context.Request.Params[SecurityToken];
    
            bool isTokenAuthorized = SecurityManager.IsTokenValid(token);
            if (isTokenAuthorized) return true;
                
            bool isDefaultAuthorized = AuthorizeCore(context);
            return isDefaultAuthorized;
        }
        catch (Exception)
        {
            return false;
        }
    }
