    // Find the user
    var user = await _userManager.FindByIdAsync(id);
    var logins = user.Logins;
    // Delete every login, if he has
    foreach (var login in logins.ToList())
    {
      await _userManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
    }
    // Delete every role, if he has
    var rolesForUser = await _userManager.GetRolesAsync(id);
    if (rolesForUser.Count() > 0)
    {
        foreach (var item in rolesForUser.ToList())
        {
           // item should be the name of the role
           var result = await _userManager.RemoveFromRoleAsync(user.Id, item);
        }
    }
    // Delete the user itself
    _await _userManager.DeleteAsync(user);
