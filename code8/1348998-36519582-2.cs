    //Returns Group Id and Role Id by using User Id parameter
    var userGroupRoles = groupManager.GetUserGroupRoles(""); 
    foreach (var role in userGroupRoles)
    {
        string roleName = RoleManager.FindById(role.ApplicationRoleId).Name;
        UserManager.AddToRole(user.Id, roleName);
    }
