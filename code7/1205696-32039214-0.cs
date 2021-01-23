    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
        var result = await SignInManager.PasswordSignInAsync(model.UserName, 
            model.Password, model.RememberMe, shouldLockout: false);
        switch (result)
        {
            case SignInStatus.Success:
                ViewBag.UserId = userId;
                return RedirectToAction("Index","User");
            case SignInStatus.LockedOut:
                return View("Lockout");
            case SignInStatus.RequiresVerification:
                return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            case SignInStatus.Failure:
                return View(model);
            default:
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
        }
    }
    public ActionResult Index()
    {
        string userID=User.Identity.GetUserId();
        // use userID in your way
    }
