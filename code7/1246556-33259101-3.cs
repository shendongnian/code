    public class MyClass
    {
    	public string Name { get; set; }
    	public byte[] MyBytes1 { get; set; }
    	public byte[] MyBytes2 { get; set; }
    }
    MyClass m = new MyClass
    {
    	Name = "Test",
    	MyBytes1 = System.Text.Encoding.Default.GetBytes("Test1"),
    	MyBytes2 = System.Text.Encoding.Default.GetBytes("Test2")
    };
  
    JsonConvert.SerializeObject(m, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new DynamicContractResolver(typeof(byte[])) });
