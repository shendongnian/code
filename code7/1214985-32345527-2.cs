    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl) 
    { 
        if (ModelState.IsValid)
    	{
            var user = await _customerUserManager.FindAsync(model.UserName, model.Password); 
    	    if (user != null)
    	    {
                var options=new IdentityOptions(); 
                var ident = new ClaimsIdentity(IdentityOptions.ApplicationCookieAuthenticationType);
                ident.AddClaims(new[] 
                {              
                    new Claim(options.ClaimsIdentity.UserIdClaimType,user.Id),
                    new Claim(options.ClaimsIdentity.UserNameClaimType, user.userName),
                    // populate assigned user roles form the DB and add each one as a claim  
                    new Claim(ClaimTypes.Role,"RoleName1"),
                    new Claim(ClaimTypes.Role,"RoleName2"),
                });
                
                Context.Authentication.SignIn(IdentityOptions.ApplicationCookieAuthenticationScheme, new ClaimsPrincipal(ident));
                return RedirectToLocal(returnUrl); 
    		} 
    		else 
    		{ 
    		    ModelState.AddModelError(string.Empty, "Invalid username or password."); 
    		} 
    	} 
    	return View(model); 
    } 
