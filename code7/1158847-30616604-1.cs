	public class RootObject
	{
		public Obj1 Obj1 { get; set; }
	}
	
	public class Obj1
	{
		public double Value { get; set; }
		public Data Data { get; set; }
	}
	
	public class Data
	{
		public double Data1 { get; set; }
		public double Data2 { get; set; }
		public double Data3 { get; set; }
	}
 
	string json = "[{\"Obj1\":{\"Value\":0.6,\"Data\":{\"Data1\":0.1,\"Data2\":0.2,\"Data3\":0.3}}}]";
	List<RootObject> result = JsonConvert.DeserializeObject<List<RootObject>>(json);
	Dictionary<double, List<double>> dict = result.ToDictionary(key => key.Obj1.Value, value => new List<double> {value.Obj1.Data.Data1, value.Obj1.Data.Data2, value.Obj1.Data.Data3});
