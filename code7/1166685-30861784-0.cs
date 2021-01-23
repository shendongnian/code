    protected override void Initialize(System.Web.Routing.RequestContext requestContext)
    {
        base.Initialize(requestContext);
        if (requestContext.HttpContext.User.Identity.IsAuthenticated)
        {
            //do something
        }
    }
