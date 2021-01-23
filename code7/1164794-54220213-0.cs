    [AllowAnonymous] // this is a login page; there is no auth yet
    public ActionResult Login()
    {
        // do stuff here
    }
    [AllowAnonymous]  
    [HttpPost]  // this accepts the request from the view
    public ActionResult Login(User user, string returnURL)
    {
        // do stuff here
    }
