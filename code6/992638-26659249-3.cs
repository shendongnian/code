    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
    var result = await UserManager.CreateAsync(user);
    if (result.Succeeded)
    {
        result = await UserManager.AddLoginAsync(user.Id, info.Login);
        if (result.Succeeded)
        {
            await StoreGooglePlusAuthToken(user);
            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            return RedirectToLocal(returnUrl);
        }
    }
