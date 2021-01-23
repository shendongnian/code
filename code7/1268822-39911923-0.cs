     //
    // POST: /Account/Login
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
        if (!ModelState.IsValid)
        {
            return Json(new { success = false, ex = "Fail to login." });
        }
        var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, shouldLockout: false);
        switch (result)
        {
            case SignInStatus.Success:
                string userId = UserManager.FindByName(model.Email)?.Id;
                return Json(new { success = true });
            case SignInStatus.Failure:
                return Json(new { success = false, ex = "Email or password was incorrect." });
            default:
                return Json(new { success = false, ex = "Fail to login." });
        }
    }
