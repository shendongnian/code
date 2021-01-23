    public ActionResult SignInConfirmation(string returnUrl)
    {
       ViewBag.ReturnUrl = returnUrl;
       return View();
    }
    
    [HttpPost]
    public ActionResult SignInConfirmation(UserCredentialsModel model, string returnUrl)
    {
    }
