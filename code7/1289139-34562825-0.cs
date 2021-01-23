    void Main()
    {
    	var x = new Test();
    	Console.WriteLine(JsonConvert.SerializeObject(x));
    }
    
    // Define other methods and classes here
    public class Test {
    	public Test()
    	{
    	TestProp = "test";
    	}
    	[JsonProperty()]
    	internal string TestProp {get;set;}
    }
