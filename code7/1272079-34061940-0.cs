	// 1. Add OtherObjectsDictionary
	// 2. Block OtherObjects in the json serialization
	public class MyObjects
	{
		public bool Active { get; set; }
		[Newtonsoft.Json.JsonIgnore]
		public List<OtherObject> OtherObjects { get; set; }
		public Dictionary<string, List<OtherObject>> OtherObjectsDictionary { get; set; }
	}
	// 3. Block Name in the json serialization
	public class OtherObject
	{
		public int Id { get; set; }
		public bool Enabled { get; set; }
		public string Address { get; set; }
		[Newtonsoft.Json.JsonIgnore]
		public string Name { get; set; }
	}
	
	// 4. Linq queries to achieve the grouped result
	// 5. Serialize to Json
	static void Main(string[] args)
	{
		var myObjects = new MyObjects() { Active = true, OtherObjects = new List<OtherObject>() };
		myObjects.OtherObjects.Add(new OtherObject { Id = 1, Name = "First" });
		myObjects.OtherObjects.Add(new OtherObject { Id = 2, Name = "First" });
		myObjects.OtherObjects.Add(new OtherObject { Id = 3, Name = "Second" });
		myObjects.OtherObjectsDictionary = new Dictionary<string, List<OtherObject>>();
		var distinctNames = myObjects.OtherObjects.Select(otherObject => otherObject.Name).Distinct();
		foreach(var distinctName in distinctNames)
		{
			var groupedObjectsList = myObjects.OtherObjects.Where(otherObject => otherObject.Name == distinctName).ToList();
			myObjects.OtherObjectsDictionary.Add(distinctName, groupedObjectsList);
		}
		var outputJson = Newtonsoft.Json.JsonConvert.SerializeObject(myObjects);
	}	
