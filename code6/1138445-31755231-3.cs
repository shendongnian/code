    [HttpPost]
    public ActionResult Login(string username, string password)
    {
        if (_userManager.IsValid(username, password)) // your own user manager 
        {
            var ident = new ClaimsIdentity(
              new[] 
              { 
                  new Claim(ClaimTypes.Name,login.UserName),
                  // populate assigned user rightID's form the DB and add each one as a claim  
                  new Claim("UserRight","FirstAssignedUserRightID"),
                  new Claim("UserRight","SecondAssignedUserRightID"),
              },
              DefaultAuthenticationTypes.ApplicationCookie);
    
            HttpContext.GetOwinContext().Authentication.SignIn(
               new AuthenticationProperties { IsPersistent = false }, ident);
            return RedirectToAction("MyAction"); // auth succeed 
        }
        // invalid username or password
        ModelState.AddModelError("", "invalid username or password");
        return View();
    }
