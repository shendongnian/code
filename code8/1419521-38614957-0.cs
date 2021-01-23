    var query = dbcontext.table1;
    
    if(age != null)
    	query = query.Where(m => m.Age == age);
    	
    if(gender != null)
        query = query.Where(m => m.Gender == gender);
    	
    return  query.Select(m => new model
    			{
    				model properties here..
    			}).ToList()
