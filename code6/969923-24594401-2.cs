    public async Task<ViewResult> Users()
    {
        var users = UserManager.Users;
        var model = new Collection<UserRoleViewModel>();
        foreach (var user in users)
        {
            var roles = await UserManager.GetRolesAsync(user.Id);
            var rolesCollection = new Collection<IdentityRole>();
            foreach (var role in roles)
            {
                var role = await RoleManager.FindByNameAsync(roleName);
                rolesCollection.Add(role);
            }
            model.Add(new UserRoleViewModel { User = user, Roles = rolesCollection });
        }
        return View("Users", model);
    }
