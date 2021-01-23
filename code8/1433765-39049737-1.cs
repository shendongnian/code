    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        if(Throw403)
        {
            filterContext.Result = new HttpStatusCodeResult(403);
        }
    }
