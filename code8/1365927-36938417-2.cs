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
            model.Roles = GetRoles();
            ModelState.AddModelError("", "You cannot login as " + model.UserRole);
            return View(model);
        }
    }
    ModelState.AddModelError("", "Invalid login attempt.");
    return View(model);
