    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
        // Return to Login View if there is an invalid model submitted (with errors displayed)
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        // Attempt to Login
        var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
        switch (result)
        {
            // If Login is successful
            case SignInStatus.Success:
                // Go to the returnUrl if there is a returnUrl (used when User has been automatically signed out or has tried to hit an unauthorized page)
                if(!string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToLocal(returnUrl);
                } else
                {
                   // Go to MainDashboard if there is no returnUrl and Login is successful (without referencing the LoginViewModel)
                    return RedirectToAction("MainDashboard", "Home");
                }
            case SignInStatus.LockedOut:
                return View("Lockout");
            case SignInStatus.RequiresVerification:
                return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            case SignInStatus.Failure:
            default:
                // If Login has failed, and it's not due to a Lockout and not because the User has to Verify the Registration code on Registration
                // Return to the Login View with errors
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
        }
    }
