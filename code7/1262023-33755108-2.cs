    public ActionResult Login(LoginModel model, string returnUrl)
    {
        string redirectUrl = returnUrl;
        string userName = model.UserName;
        UserProfile user = dbAccount.UserProfiles.Where(m => m.Email.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault();
        if (user != null)
        {
            userName = user.UserName;
        }
    
        if (ModelState.IsValid && WebSecurity.Login(userName, model.Password, persistCookie: model.RememberMe))
        {
            return  this.RedirectToAction("AdminRedirect","Account", new {redirectUrl = redirectUrl});           
        }
        // If we got this far, something failed, redisplay form
        ModelState.AddModelError("", "The user name or password provided is incorrect.");         
        return View(model);
    }
    public ActionResult AdminRedirect(string redirectUrl)
    {
         if (redirectUrl == null)
         {
               redirectUrl = User.IsInRole("Admin") ? "/Admin" : "/";
         }
         return this.RedirectToLocal(redirectUrl);
     }
