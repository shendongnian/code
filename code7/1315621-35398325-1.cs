    public void Add(Logged user)
    {
    	if (!UserList.Any(u => u.Username == user.Username))
    	{
    		UserList.Add(user);
    	}
    }
