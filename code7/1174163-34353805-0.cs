	Server server = new Server();
	server.Connect("Data source=" + cubeServerName + ";Timeout=7200000;Integrated Security=SSPI;");
	
	Database db = server.Databases.FindByName(cubeName);
	if (db.Roles.Find("MyRole") == null)
	{
		Role newRole = db.Roles.Add("MyRole");
		RoleMember r = new RoleMember(userDomain + "\\" + userName);
		newRole.Members.Add(r);
		newRole.Update();
	}
	DatabasePermission dbperm;
	var role = db.Roles.Find("MyRole");
	dbperm = db.DatabasePermissions.Add(role.ID);
	dbperm.Process = true; //I want to add process permission
	dbperm.Update();     
