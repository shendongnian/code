    public class Result
    {
    	public Result()
    	{ 
            // initialize collection
    		Items = new List<Item>();
    	}
    	
    	public string Percentage { get; set; }
    	public string Bullets { get; set; }
    	public IList Items  { get; set; }
    	
    }
    
    public class Item
    {
       public int Value { get; set; }
       public string Text { get; set; }
       public string Prefix { get; set; }
       public string Label { get; set; }
    }
