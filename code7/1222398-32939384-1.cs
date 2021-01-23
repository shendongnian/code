    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> EmailConfirmed(ConfirmTokenViewModel model)
    {
        if (!this.ModelState.IsValid)
    return View("Error");
    
        bool succeeded = await this._accountsManager.ConfirmEmail(model.UserId, model.Token);
        return succeeded ? View() : View("Error");
    }
    public async Task<bool> ConfirmEmail(string userId, string token)
    {
        User user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
    var result = await _userManager.ConfirmEmailAsync(user, token);
    return result.Succeeded;
        }
    
        return false;
    }
