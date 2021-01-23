    // Add to role, save changes
    await _userManager.AddToRoleAsync(userInSession.Id, roleHaveClients.Name);
    await _userManager.UpdateAsync(userInSession);
    // Sign out / Sing in
    _registerManager.AuthenticationManager.SignOut();
    await __registerManager.SignInAsync(userInSession, false, false);
    // Redirect to another action
    return RedirectToAction("someAction","someController");
    
