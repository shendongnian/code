    [HttpPost]
    public ActionResult Login(string username, string password)
    {
        if (new UserManager.IsValid(username, password))
        {
            var ident = new ClaimsIdentity(
              new[] { new Claim(ClaimTypes.Name,login.UserName) },
              DefaultAuthenticationTypes.ApplicationCookie);
        
            HttpContext.GetOwinContext().Authentication.SignIn(
               new AuthenticationProperties { IsPersistent = false }, ident);
            return RedirectToAction("MyAction"); // auth succeed 
        }
        // invalid username or password
        ModelState.AddModelError("", "invalid username or password");
        return View();
    }
