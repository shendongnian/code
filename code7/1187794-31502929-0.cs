    [AllowAnonymous]
    public ActionResult Login(string returnUrl) 
    {
        if (Request.QueryString["returnFrom"] != null) 
        {
            // return the Login view... 
        }
    }
    [HttpPost]
    public ActionResult Login(User user) 
    {
        // Check if the user is authorized...
    }
