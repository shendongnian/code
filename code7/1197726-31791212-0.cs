    [Authorize]
    public ActionResult Foo()
    {
       var user = User.Identity.Name; // WIN
    }
