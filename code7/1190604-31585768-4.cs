    [HttpPost]
    public ActionResult Login(string username, string password)
    {
        if (new UserManager.IsValid(username, password))
        {
            var ident = new ClaimsIdentity(
              new[] { 
                  // adding following 2 claim just for supporting default antiforgery provider
                  new Claim(ClaimTypes.NameIdentifier, username),
                  new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
                  
                  new Claim(ClaimTypes.Name,username),
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
