	void Main()
	{
		List<CSpropr> listActionpropr = CSpropr.searchList("act"); // Get a list of all records of table PROPR for the 'actioncondition' specified
		List<CSpropr> preservedList = listActionpropr.DeepCopy(); // Get a list of all records of table PROPR for the 'actioncondition' specified
		// For each record...
		foreach (CSpropr instance in listActionpropr)
		{
			instance.ValName = "John";
			instance.ValPhone = 323234232;
			instance.update(); // This make and UPDATE of the record in DB
		}
	
		foreach (CSpropr instance1 in preservedList )
		{
			instance1.update();
		}
	}
	
	// Define other methods and classes here
	[Serializable]
	public class CSpropr {
		public string ValName {get;set;}
		public int ValPhone {get;set;}
		
		public void update() {
			ValName.Dump();
			ValPhone.Dump();
		}
		
		public static List<CSpropr> searchList(string act) {
			return new List<CSpropr> { new CSpropr {ValName = "First", ValPhone = 4444} , new CSpropr {ValName = "First", ValPhone = 4444 }};	
		}
	}
	
	public static class GenericCopier
	{
		public static T DeepCopy<T>(this T original) where T : class
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(memoryStream, original);
				memoryStream.Seek(0, SeekOrigin.Begin);
				return (T)binaryFormatter.Deserialize(memoryStream);
			}
		}
	}
