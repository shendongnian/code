    if ((UserManager.IsInRole(user.Id, "Admin")) || (UserManager.IsInRole(user.Id, "User")))
    {
    await SignInAsync(user, model.RememberMe);
    return RedirectToLocal(returnUrl);
    }
