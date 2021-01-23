    var user = new ClaimsPrincipal(AuthenticationManager.AuthenticationResponseGrant.Identity);
    if (!user.IsInRole(model.UserRole))
    {     
        AuthenticationManager.AuthenticationResponseGrant = null;
        return RedirectToLocal(returnUrl);
    }
