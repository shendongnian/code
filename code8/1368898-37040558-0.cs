    public class MyBadArray
    {
    	public Customer this[int a]
    	{
    		get
    		{
    			throw new OutOfMemoryException();
    		}
    	}
    }
    var customers = new MyBadArray(); 
	int? count = customers?[5]?.Orders?.Count();
