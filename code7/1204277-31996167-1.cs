    [Authorize]
    public ActionResult Foo()
    {
    }
    // since we injected user roles to Identity we could do this as well
    [Authorize(Roles="admin")]
    public ActionResult Foo()
    {
    }
