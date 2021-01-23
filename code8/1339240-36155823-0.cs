	public class TestClass
	{
		public double Value
		{
			get { return (double)IntValue; }
			set { _IntValue = (int)value; }
		}
		private int _IntValue;
		[JsonIgnore]
		public int IntValue {
			get { return _IntValue; }
			set { _IntValue = value; }
		}
	}
	static void Main(string[] args)
	{
		var json = "{Value:9.658055e+06}";
		var xx = JsonConvert.DeserializeObject<TestClass>(json);
		
		Console.WriteLine(JsonConvert.SerializeObject(xx));
		Console.WriteLine(xx.IntValue); 
		Console.ReadKey();
	}
