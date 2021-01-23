    [HttpPost]
    public ActionResult Login(LoginViewModel model, string returnUrl)
    {
        var user = _userService.GetByEmail(model.Email);
        //check username and password from database.
        if (user != null && (user.Password == model.Password)) 
        {
            var claims = new[] {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    // can add more claims
                };
            // Add roles into claims
            var roles = _roleService.GetByUserId(user.Id).ToList();
            if (roles.Any())
            {
                var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r.Name));
                identity.AddClaims(roleClaims);
            }
            var identity = new ClaimsIdentity(claims, DefaultApplicationTypes.ApplicationCookie);
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;
            authManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);
            return RedirectToAction("Index", "Home");
        }
        // login failed.            
    }
    public ActionResult LogOut()
    {
        var ctx = Request.GetOwinContext();
        var authManager = ctx.Authentication;
        authManager.SignOut(DefaultApplicationTypes.ApplicationCookie);
        return RedirectToAction("Login");
    }
