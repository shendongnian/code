    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl) 
    { 
        if (ModelState.IsValid)
    	{ 
    	    var user = await _customerUserManager.FindAsync(model.UserName, model.Password); 
    		if (user != null)
    		{ 
                var ident = new ClaimsIdentity(
                new[] 
                {
                    // adding following 2 claim just for supporting default antiforgery provider
                    new Claim(ClaimTypes.NameIdentifier, LoginModel.EmailAddr),
                    new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
                
                    new Claim(ClaimTypes.Name,login.UserName),
                    // populate assigned user roles form the DB and add each one as a claim  
                    new Claim(ClaimTypes.Role,"RoleName1"),
                    new Claim(ClaimTypes.Role,"RoleName2"),
                },
                DefaultAuthenticationTypes.ApplicationCookie);
                
                HttpContext.GetOwinContext().Authentication.SignIn(
                   new AuthenticationProperties { IsPersistent = false }, ident);
                return RedirectToLocal(returnUrl); 
    		} 
    		else 
    		{ 
    		    ModelState.AddModelError(string.Empty, "Invalid username or password."); 
    		} 
    	} 
    	return View(model); 
    } 
