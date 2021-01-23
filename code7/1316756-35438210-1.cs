	public class MyClass
	{
		public List<YourObjects> YourObjects { get; set; } 
		
		public void ConstructListFromJSON()
		{
			YourObjects = JsonUtility.FromJson<List<MyObjects>("myObjects.json");
		}	
	}
