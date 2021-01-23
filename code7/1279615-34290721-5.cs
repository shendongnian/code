	void Main()
	{
		var json = "{\"0\":\"test\"}";
		var obj = JsonConvert.DeserializeObject<X>(json);
		Console.WriteLine(obj.Foo);
	}
	
	public class X
	{
		[JsonProperty("0")]
		public string Foo { get; set; }
	}
	
