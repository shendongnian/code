    public class Item 
    {
    	public int Aid {get;set;}
    	
    	public int Bid {get;set;}
    	
    	public DateTime CDate {get;set;}
    }
    
    void Main()
    {
    	var items = new List<Item>
    	{
    		new Item { Aid = 1, Bid = 2, CDate = new DateTime(2015, 5, 24)},
    		new Item { Aid = 3, Bid = 6, CDate = new DateTime(2015, 5, 24)},
    		new Item { Aid = 1, Bid = 2, CDate = new DateTime(2015, 5, 23)},		
    	};
    	
    	var result =  items.GroupBy(i => i.Aid)
                      .Select(group => 
                            new { Key = group.Key,
                                  Items = group.OrderByDescending(x => x.CDate) })
                      .Select (g => g.Items.First());
    					
    	
    	result.Dump();
    }
