    public async Task GeneratePasswordTokenAndSendEmailAsync(string email)
    {
        var user = await _userManager.FindByNameAsync(email);
        if (user != null && await _userManager.IsEmailConfirmedAsync(user))
        {
    string token = await _userManager.GeneratePasswordResetTokenAsync(user);
    string callbackUrl = this._urlHelper.Action("ResetPassword", "Account", new ConfirmTokenViewModel(user.Id, token), protocol: this._contextAccessor.HttpContext.Request.Scheme);
    
    await this._emailService.SendAsync(
        to: user.Email,
        subject: "Reset password",
        body: "Reset your password by clicking this link: <a href=\"" + callbackUrl + "\">link</a>"
    });
        }
    }
    
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
    IdentityResult result = await this._accountsManager.ResetPasswordAsync(model);
    if (result.Succeeded)
    {
        return RedirectToAction(nameof(ResetPasswordConfirmation), "Account");
    }
    else
        ModelState.AddModelErrors(result.Errors);
        }
    
        // If we got this far, something failed, redisplay form
        return View(model);
    }
    
    public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordViewModel model)
    {
        IdentityResult result = IdentityResult.Success;
    
        if (model != null && !string.IsNullOrWhiteSpace(model.UserId))
        {
    User user = await _userManager.FindByIdAsync(model.UserId);
    if (user != null)
        result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
        }
    
        return result;
    }
