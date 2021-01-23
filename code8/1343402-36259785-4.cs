    public class DataItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DataItem RefItem { get; set; }
    }
    
    public class MyException: Exception
    {
        public MyException(string message) : base(message)
        {
        }
    }
    
    public static class Checker
    {        
        public static bool Check(DataItem item)
        {
            var chain = new List<DataItem>();
            chain.Add(item);
            try
            {
                ProcessNodes(chain, item);
                return true;
            }
            catch(MyException)
            {
                return false;
            }
        }
    
        private static void ProcessNodes(List<DataItem> chain, DataItem item)
        {
            if(item.RefItem != null)
            {
                if (chain.Contains(item.RefItem))
                    throw new MyException("Dependency!");
                chain.Add(item.RefItem);                
                ProcessNodes(chain, item.RefItem);
            }            
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
		var items = new List<DataItem>();
        items.Add(item1);
        items.Add(item2);
        items.Add(item3);
        var result = new List<bool>();        
        foreach (var item in items)
        { 
            result.Add(Checker.Check(item));
            Console.WriteLine(string.Format("item {0} is {1}.", item.Name, result.Last() ? "ok" : "with dependency"));
        }
        Console.WriteLine(result.All(x => x) ? "All items is OK" : "At most one item has dependency");
    }
