    if (result == SignInStatus.Success)
    {
        var user = new ClaimsPrincipal(AuthenticationManager.AuthenticationResponseGrant.Identity);
        if (user.IsInRole(model.UserRole))
        {     
             return RedirectToLocal(returnUrl);
        }
        else
        {
            AuthenticationManager.AuthenticationResponseGrant = null;
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }
    }
