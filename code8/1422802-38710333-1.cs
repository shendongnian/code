    public ActionResult Login(string username, string pass, string returnUrl)
    {
       // code to authenticate user here...
       if (!string.IsNullOrEmpty(returnUrl))
         return Redirect(returnUrl);
       return RedirectToAction("Index", "Home");
    }
