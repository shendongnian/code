    [HttpPost("Auth/SignIn")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);
            if (result.Succeeded)
            {
                // Resolve the user via their email
                var user = await _userManager.FindByEmailAsync(model.Email);
                // Get the roles for the user
                var roles = await _userManager.GetRolesAsync(user);
        
                // Do something with the roles here
            }
            else
            {
                // Uh oh....
            }
        }
        // Something is probably wrong, provide the form again....
        return View(model);
    }
