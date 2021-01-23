     void Main()
    {
    	var groups = Group.CreateList();
    	
    	var locations = Location.CreateList();
    	
    	var result =
    	groups.Join(locations,g=>g.id,l=>l.groupId,(g,l)=>new {l})
    	      .GroupBy(x =>x.l.groupId,x=>x.l.count)
    		  .Select(y=>new Test
    					{
    					groupId= y.Key,
    					tables = y.Select(n => new tbl{count = n})
    					});
    					
    		result.Dump();
    	} 
    	
    public class Group
    {
    	public int id;
    	public string name;
    	
    	public static List<Group> CreateList()
    	{
    	return new List<Group>
    		{
    			new Group
    			{
    			id = 1,
    			name = "NW"
    			},
    			new Group
    			{
    			id = 2,
    			name = "SW"
    			},
    			new Group
    			{
    			id = 3,
    			name = "NE"
    			}
    		};
    	}
    }
    
    public class Location
    {
    	public int id;
    	public int groupId;
    	public int count;
    	
    	public static List<Location> CreateList()
    	{
    	return new List<Location>
    		{
    			new Location
    			{
    			id = 1,
    			groupId = 1,
    			count = 34
    			},
    			new Location
    			{
    			id = 2,
    			groupId = 2,
    			count = 5
    			},
    			new Location
    			{
    			id = 3,
    			groupId = 2,
    			count = 90
    			},
    			new Location
    			{
    			id = 4,
    			groupId = 1,
    			count = 33
    			},
    			new Location
    			{
    			id = 5,
    			groupId = 1,
    			count = 23
    			}
    		};
    	}
    }
    
    public class Test  
    {
       public int groupId {get; set;}
       public IEnumerable<tbl> tables {get; set;}
    }
    public class tbl
    {
      public int count {get; set;}
    }
