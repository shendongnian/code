    public IEnumerable<SimpleUser> GetUsers()
    {
    	return this.DbContext
    		.Users
    		.Select(z => new SimpleUser
    		{
    			ID = z.ID,
    			Name = z.Name,
    			FirstName = z.FirstName
    		})
    		.ToList();
    }
