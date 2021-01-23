    public class AB
    {
        private List<Foo> GetDetailsByQuery(string query)
    	{
    	   //excuting query
    	   return list;
    	}
    
    	public List<Foo> GetDetails(bool IsActive)
    	{
    		//creating query by isActive
    		return GetDetailsByQuery(query);
    	}
    	
    	public List<Foo> GetDetails(int Id)
    	{
    		//creating query by id
    		return GetDetailsByQuery(query); 
    	}
    }
