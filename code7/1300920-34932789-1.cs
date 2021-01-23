    ....
    string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
    //Before creating the url you could store the code somewhere to be retrieved later
    var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
    await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
    return RedirectToAction("ForgotPasswordConfirmation", "Account");
    ....
