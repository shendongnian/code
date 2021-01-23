    public void Add(Logged user)
    {
    	if (!UserList.Any(x => x == user))
    	{
    		UserList.Add(user);
    	}
    }
