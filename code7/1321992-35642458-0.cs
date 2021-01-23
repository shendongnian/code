    void AddPermissions(DAO.Database db, string tableName, string groupName, IList<DAO.PermissionEnum> addFlags)
    {
    	var container = db.DaoDB.Containers["Tables"];
    	var document = container.Documents[tableName];
    	document.UserName = groupName;
    
    	int permissions = document.Permissions;
    	foreach (var flag in addFlags)
    	{
    		permissions = permissions | (int)flag;
    	}
    
    	document.Permissions = permissions;
    }
