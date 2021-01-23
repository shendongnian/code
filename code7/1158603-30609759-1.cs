	public class ListOfVariablesToSave : List<ListOfThings<int>>
	{
		public ListOfThings<int> controlDB { get; set; }
		public ListOfThings<int> interacDB { get; set; }
		
		public ListOfVariablesToSave()
		{
			controlDB = new ListOfThings<int>() { 1, 2, 3  };
			controlDB.Name = "controlDB";
			interacDB = new ListOfThings<int>() { 21, 22, 23 };
			interacDB.Name = "interacDB";
			
			Add(controlDB);
			Add(interacDB);
		}
		
	}
	
	public class ListOfThings<T> : List<T>
	{
		public string Name { get; set; }
		
		public ListOfThings() : base() { }
	}
