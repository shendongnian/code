    public class MyItems : AbstractItem
    {
    	public MyItems(int copyNumber, string itemName, DateTime time, int guid)
    		:base(copyNumber, itemName, time, guid)
    	{
    	}
    	
        public DateTime? TimePrinted { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public bool? BestSeller { get; set; }
    }
