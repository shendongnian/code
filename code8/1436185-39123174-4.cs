	var doesPasswordMatch = false;
	
	var user = db.AspNetUsers.SingleOrDefault(x => x.UserName == username);
	if(user != null)
	{
	    var hashedPassword = Crypto.HashPassword(password);
		// var doesPasswordMatch = //compare u.PasswordHash with hashedPassword in memory
	}
	return doesPasswordMatch;
