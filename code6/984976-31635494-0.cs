    var adminRoleExists = Roles.RoleExists(AppRoles.Admin.ToString());
    if (!adminRoleExists)
    {
        Roles.CreateRole(AppRoles.Admin.ToString());
    }
