    void Main()
    {
    	var fixture = new Fixture();
    	
    	var daysCoverList = fixture.CreateMany<DaysCoverReport>(10);
    	
    	// Group by customer code and description.
    	var grouped = daysCoverList.GroupBy(dcl => new 
    	{ 
    		CustomerCode = dcl.CustomerCode, 
    		ItemDescription = dcl.ItemDescription, 
    	})
    	.Select(grp => new 
    	{ 
    		CustomerCode = grp.Key.CustomerCode, 
    		ItemDescription = grp.Key.ItemDescription, 
    		GroupedByDate = grp.ToLookup(g => g.StartDate.Date, g => g.Dur)
    	});
    	
    	var columns = grouped
    		.SelectMany(grp => grp.GroupedByDate.Select(g => g.Key))
    		.Distinct()
    		.OrderBy(d => d);
    
    	// Write column headings.
    	Console.Write("Customer Code\t");
    	Console.Write("Item Desc.\t");
    	foreach(var dateColumn in columns)
    	{
    		Console.Write(dateColumn.ToString() + "\t");
    	}
    	Console.WriteLine();
    	
    	// Write values.
    	foreach(var line in grouped)
    	{
    		Console.Write(line.CustomerCode);
    		Console.Write("\t");
    		Console.Write(line.ItemDescription);
    		Console.Write("\t");
    		
    		foreach(var dateColumn in columns)
    		{
    			if(line.GroupedByDate.Contains(dateColumn))
    			{
    				Console.Write(line.GroupedByDate[dateColumn].Sum());
    			}
    			else
    			{
    				Console.Write(0);
    			}
    			
    			Console.Write("\t");
    		}
    		Console.WriteLine();
    	}
    }
    
    public class DaysCoverReport
    {
        public string SupplierCode { get; set; }
        public string CustomerCode { get; set; }
        public DateTime StartDate { get; set; }
        public int Dur { get; set;}
    	public string ItemDescription { get;set;}
    }
