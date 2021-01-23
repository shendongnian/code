    var roleManager = new RoleManager();
    foreach (var user in ApplicationDbContextInstance.Users)
    {
        List<IdentityUserRole> UserRoles = user.Roles.ToList();
        foreach(var userRole in UserRoles)
        {
            var role = roleManager.FindbyId(userRole.RoleId);
        }
    }
