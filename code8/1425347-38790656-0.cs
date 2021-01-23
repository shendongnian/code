    public IList<User> getUsers (List<int > ids = null)
    {        	    		
    		var query = _repository.GetEntities<User>();
    		
    		if (ids == null)        		
    			return query.ToList();        			
    		
    		if (ids.Count()==1)
    		{       			 
    			 var singleUser = query.FirstOrDefault(user => ids.Contains(user.Id));
    			 if (singleUser!= null)        			      			 	
    			 	return new List<User>{ singleUser; };      		
    			 
    			 return new List<User>();      			 
    		}   
    		
    		return query.Where(user => ids.Contains(user.Id)).ToList();       		        	  		       	       		
    }
