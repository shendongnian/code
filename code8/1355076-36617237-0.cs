    class Program
    {
    	public class SomeClass
    	{
    		public string SomeProperty { get; set; }
    
    		public byte[] ByteArrayProperty { get; set; }
    	}
    
    	
    
    	static void Main()
    	{
    		SomeClass sc = new SomeClass()
    		{
    			SomeProperty = "la la la",
    			ByteArrayProperty = new byte[] {1, 2, 3}
    		};
    
    		string json = JsonConvert.SerializeObject(sc);
    
    		SomeClass newSC = JsonConvert.DeserializeObject<SomeClass>(json);
    
    	}
    }
