    [HttpPost]
    [AllowAnonymous]
    public ActionResult Login(LoginModel lm, string returnUrl) {
        using (WorkLayer dal = new WorkLayer()) {
            if (ModelState.IsValid) {
                string password = dal.Users.GetUserInfo(lm.UserName).HashPassword.ToString();
    
                if (!string.IsNullOrEmpty(password) && lm.HashPassword.Equals(password)) {
                    FormsAuthentication.SetAuthCookie(lm.UserName, false);
                    return RedirectToAction("AdminPanel");
                } else {
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");                    
                }
            } 
        }
        return View(lm);
    }
