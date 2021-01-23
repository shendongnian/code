	ApplicationGroupManager gm = new ApplicationGroupManager();
	string roleName = RoleManager.FindById("").Name; //Returns Role Name by using Role Id 
	var userGroupRoles = gm.GetUserGroupRoles(""); //Returns Group Id and Role Id by User Id var 
    groupRoles = gm.GetGroupRoles(""); //Returns Group Roles by using Group Id
	string[] groupRoleNames = groupRoles.Select(p => p.Name).ToArray(); //Assing Group Role Names to a string array
