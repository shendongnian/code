    using System;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Request r = new Request();
    		r.Arguments[0] = new TestObject("111111");
    		r.Arguments[1] = new TestObject("222222");
    		
    		string output = JsonConvert.SerializeObject(r, Formatting.Indented, new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.All
    });
    		Console.WriteLine(output);
    		Request deserializedr = JsonConvert.DeserializeObject<Request>(output, new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.Auto
    });
    																	   
    		Console.WriteLine(deserializedr.Command);
    		Console.WriteLine(((TestObject)(deserializedr.Arguments[0])).Name );
    		Console.WriteLine(((TestObject)(deserializedr.Arguments[1])).Name );
    	}
    }
    	public class Request
    {
    		public Request(){
    			Command = "boquepasa";
    			Arguments = new Object[2];
    		}
        public string Command { get; set; }
        public object[] Arguments { get; set; }
    }
    
    public class TestObject
    {
    	public TestObject(string name)
    	{
    		ID = Guid.NewGuid();
    		Name = name;
    	}
    
    	public string Name { get; set; }
    	public Guid ID { get; set; }
    }
