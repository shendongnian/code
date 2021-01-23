    void Main()
    {
    	var testList = Test.Create();
    	
    	var result = 
    	testList.GroupBy(x=>new {
    	                      x.OwnerName,
    						  x.OwnerId,
    						  x.ReleaseDates
    	                        })
    			.Select(y=>new {
    			               y.Key.OwnerName,
    						   y.Key.OwnerId,
    						   statusU = y.Where(m=>m.status == "U").Count(),
    						   statusS = y.Where(m=>m.status == "S").Count(),
    							});
    							
    	result.Dump();
    	
    	var result1 = 
    	testList.GroupBy(x=>new {
    	                      x.OwnerName,
    						  x.OwnerId,
    						  x.ReleaseDates
    	                        },x=>x.status)
    			.Select(y=>new {
    			               y.Key.OwnerName,
    						   y.Key.OwnerId,
    						   statusU = y.Count(m=>m=="U"),
    						   statusS = y.Count(m=>m=="S"),
    							});
    							
    	result1.Dump();
    }
    
    public class Test
    {
    	public string OwnerName {get; set;}
    
    	public int OwnerId {get; set;}
    
    	public string status {get; set;}
    	
    	public DateTime ReleaseDates{get; set;}
    	
    	public static List<Test> Create()
    	{
    	  return new List<Test>()
    		{
    		
    		new Test
    		{
    		  OwnerName = "ABCD",
    		  OwnerId = 1,
    		  status = "S",
    		  ReleaseDates = DateTime.Now
    		},
    		new Test
    		{
    		  OwnerName = "ABCD",
    		  OwnerId = 1,
    		  status = "S",
    		  ReleaseDates = DateTime.Now
    		},
    		new Test
    		{
    		  OwnerName = "ABCD",
    		  OwnerId = 1,
    		  status = "S",
    		  ReleaseDates = DateTime.Now
    		},
    		new Test
    		{
    		  OwnerName = "ABCD",
    		  OwnerId = 1,
    		  status = "U",
    		  ReleaseDates = DateTime.Now
    		},
    		new Test
    		{
    		  OwnerName = "ABCD",
    		  OwnerId = 1,
    		  status = "U",
    		  ReleaseDates = DateTime.Now
    		},
    		new Test
    		{
    		  OwnerName = "ABCD",
    		  OwnerId = 1,
    		  status = "S",
    		  ReleaseDates = DateTime.Now
    		}
    		
    		};
    	}	
    }
