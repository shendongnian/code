    ApplicationUser user = UserManager.FindByName(model.UserName);
    string userId = user != null ? user.Id : null;
    var roles = userId != null ? UserManager.GetRoles(userId) : null;
    if (roles != null)
    {
        foreach (var item in roles)
        {
            //Assign user roles
            UserManager.AddToRole(userId, item);
        }
    }
