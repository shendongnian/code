	public class Country {
		public string id {get; set;}
		public string name {get; set;}
	}
	// In using method ...
	{
		List<Country> list1 = // assign countries
		// Either 
		List<string> list2 = new List<string>();
		list1.Select(c => c.name).ForEach(list2.Add);
		// OR
		var list2 = list1.Select(c => c.name).ToList();
	}
