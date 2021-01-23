    public class Program
    {
    	public static void Main()
    	{
    		var address = new Address();
    		
    		var type = address.GetType();
    		
    		var props = type.GetProperties();
    		
    		foreach(var property in props)
    		{
    			Console.WriteLine(property.Name);
    		}
    	}
    	
    	
    }
    
    public class Address
    {
        public string address{ get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string code { get; set; }
    }
