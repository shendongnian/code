    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
    var callbackUrl = Url.Action("ConfirmEmail", "Account", new
        {
            userId = user.Id,
            code = code,
            returnUrl = model.ReturnUrl
        }, protocol: Request.Url.Scheme);
