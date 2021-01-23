    public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
    {
        var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
        if (loginInfo == null)
        {
            return RedirectToAction("Login");
        }
        var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
        if(result==SignInStatus.Success)
        {
            var user=UserManager.Find(loginInfo.Login);
            returnUrl =UserManager.IsInRole(user.Id, "Administrator")
                ? "~/admin"
                : "~/dashboard";
            
        }
        // rest of code
    }
