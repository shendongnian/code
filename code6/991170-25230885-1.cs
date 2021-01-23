    public YourClass[] AllProducts()
    {
    	try
    	{
    	    using (UserDataDataContext db = new UserDataDataContext())
    	    {
    			return db.mrobProducts.Where(x => x.Status == 1)
    						   .OrderBy(x => x.ID)
    						   .Select(x => new YourClass { ID = x.ID, Name = x.Name, Price = x.Price})
    						   .ToArray();
    		}
    	}
    	catch
    	{
    	    return null;
    	}
    }
