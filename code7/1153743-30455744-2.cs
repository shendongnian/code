	private void OwinSignIn(User user, bool isPersistence = false)
    {
        var claims = new[] {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email)
                };
        var identity = new ClaimsIdentity(claims, DefaultApplicationTypes.ApplicationCookie);
        var roles = _roleService.GetByUserId(user.Id).ToList();
        if (roles.Any())
        {
            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r.Name));
            identity.AddClaims(roleClaims);
        }
        var context = Request.GetOwinContext();
        var authManager = context.Authentication;
        authManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistence }, identity);
    }
    [HttpPost]
    public ActionResult Login(LoginViewModel model, string returnUrl)
    {
        if (!ModelState.IsValid)
            return View();
        var user = _userService.GetByEmail(model.Email);
        if (user != null && (user.Password == model.Password))
        {
            OwinSignIn(user, model.RememberMe);
            return RedirectToLocal(returnUrl);
        }
        ModelState.AddModelError("", "Invalid email or password");
        return View();
    }
