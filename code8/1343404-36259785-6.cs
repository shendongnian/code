    public class DataItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DataItem RefItem { get; set; }
    }    
    
    public class Checker
    {
        public static bool Check(DataItem item)
        {
            var chain = new Dictionary<DataItem, DataItem>();
            chain.Add(item, null);
            try
            {
                ProcessNodes(chain, item);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    
        private static void ProcessNodes(Dictionary<DataItem, DataItem> chain, DataItem item)
        {
            if (item.RefItem != null)
            {                
                chain.Add(item.RefItem, null);
                ProcessNodes(chain, item.RefItem);
            }
        }
    	
    	public static bool ValidateDataItems(List<DataItem> items)
        {
    		foreach(var item in items)
    			if(!Check(item))
    				return false;
    		return true;				
    	}
    }
    
    public static void Main()
    {
        var item1 = new DataItem() { ID = 1, Name = "First Item", RefItem = null };
        var item2 = new DataItem() { ID = 1, Name = "First Item", RefItem = item1 };
        var item3 = new DataItem() { ID = 1, Name = "First Item", RefItem = item2 };
        item1.RefItem = item3;
    
        Console.WriteLine(Checker.Check(item1));
        item1.RefItem = null;
        Console.WriteLine(Checker.Check(item1));
    
        //Sample how to check all existing items	
        Console.WriteLine(Checker.ValidateDataItems(new List<DataItem>{item1, item2, item3}) ? "items is OK" : "One or more items have dependency");        
    }
