    public bool AddRoleToUser(int portalid, UserInfo user, string roleName, DateTime expiry)
    {
    	bool rc = false;
    	if (user != null)
    	{
    		var roleCtl = new RoleController();
    		RoleInfo newRole = roleCtl.GetRoleByName(portalid, roleName);
    		if (newRole != null)
    		{
    			roleCtl.AddUserRole(portalid, user.UserID, newRole.RoleID, DateTime.MinValue, expiry);
    			// Refresh user and check if role was added
    			user = UserController.GetUserById(portalid, user.UserID);
    			rc = user.IsInRole(roleName);
    		}
    	}
    	return rc;
    }
