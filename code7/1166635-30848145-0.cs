    public string IsAuthenticUser(string userId, string password)
    {
        var AuthenticUsers = System.Configuration.ConfigurationManager.AppSettings["authenticUsers"];
        return AuthenticUsers 
	        .Split(',')
         	.Select(user=> new
        	{
        		login = user.Split(':').First(),
        		password = user.Split(':').Last().Split('=').First(),
    	     	role = user.Split(':').Last().Split('>').Last(),
        	})
            .Any(user=>user.login == userId && user.password == password);
    }
