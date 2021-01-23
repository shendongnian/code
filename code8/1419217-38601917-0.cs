    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		var NoLiftingList = new List<SQLFields>
    		{
    			new SQLFields
    			{
    				Field1 = "No Lifting"
    			},
    			new SQLFields
    			{
    				Field1 = "Up to 100lbs (extreme lifting)"
    			}			
    		};
    	}
    }
    
    public class SQLFields
    {
    	public string Field1 { get; set; }
    }
	
