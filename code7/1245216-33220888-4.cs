    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
    if (!ModelState.IsValid)
    {
        return View(model);
    }
    // check if username/password pair match.
    var loggedinUser = await UserManager.FindAsync(model.Email, model.Password);
    if (loggedinUser != null)
    {
        // change the security stamp only on correct username/password
        await UserManager.UpdateSecurityStampAsync(loggedinUser.Id);
    }
     // do sign-in
    var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
    switch (result)
    {
        case SignInStatus.Success:
            return RedirectToLocal(returnUrl);
        case SignInStatus.LockedOut:
            return View("Lockout");
        case SignInStatus.RequiresVerification:
            return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
        case SignInStatus.Failure:
        default:
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
    }
