    protected override void Initialize(RequestContext requestContext)
    {
    
        new GlobalisationCookie(requestContext.HttpContext.Request, requestContext.HttpContext.Response).CheckGlobalCookie();
      
        base.Initialize(requestContext);
    }
