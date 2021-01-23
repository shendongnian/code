    [Authorize]
    public ActionResult Foo()
    {
    }
    // since we injected user roles to Identity we could do this as well
    [Authorize(Roles="admin")]
    public ActionResult Foo()
    {
        // since we injected our authentication mechanism to Identity pipeline 
        // we have access current user principal by calling also
        // HttpContext.User
    }
