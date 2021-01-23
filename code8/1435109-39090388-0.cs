    string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
    //For MVC controller
    var callbackUrl = Url.Action("ResetPassword", "Account", new { code = code }, protocol: Request.Url.Scheme);
    //For Web API controller
    var callbackUrl = Url.Link("Default", new { Controller = "Account", Action = "ResetPassword", code = code });
