    [AllowAnonymous]
    public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
    {
        // Require that the user has already logged in via username/password or external login
        if (!await SignInManager.HasBeenVerifiedAsync())
        {
            return View("Error");
        }
        return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
    } 
