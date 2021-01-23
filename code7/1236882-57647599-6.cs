    public class JsonTest
	{
		[JsonProperty("theArray")]
		public dynamic[] TheArray { get; set; }
	}
    var json = "{'theArray':[{'a':'First'},{'a':'Second'}]}";
	var jsonTest = JsonConvert.DeserializeObject<JsonTest>(json);
		
    var myCast = new DynamicCast<MyType>();
	var myTypes = myCast.Cast(jsonTest.TheArray).ToArray();
	Console.WriteLine(myTypes[0].A); // prints 'First'
