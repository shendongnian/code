    public CustomerMain FindOne(string firstName)
    {
    	using (var context = new CustomerEntities())
        {    
        	var query = context.CustomerMains.Where(p => p.FirstName == firstName);
    
    	    return query.FirstOrDefault();
        }
    }
