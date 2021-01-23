    	public static void Main()
	{
		var list = new List<SomeClass>
		{
			new SomeClass{ Status = "Recruiting"},
			new SomeClass{ Status = "Completed"},
			new SomeClass{ Status = "Active and not Recruiting"},
			new SomeClass{ Status = "Completed"},
			new SomeClass{ Status = "Recruiting"}
		};
		
		PrintList(list);
		
		Console.WriteLine("-");
		
		var sorted = list
			.OrderBy(sc => sc.Status.Equals("Recruiting", StringComparison.OrdinalIgnoreCase)
				? 0
				: sc.Status.Equals("Active and not Recruiting", StringComparison.OrdinalIgnoreCase)
					 ? 1
					 : sc.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase)
					 	? 2
					  	: 3)
			.ToList();
		
		
		PrintList(sorted);
	}
	public static void PrintList(IEnumerable<SomeClass> list)
	{
		foreach(var sc in list) Console.WriteLine(sc.Status);
	}
	
	public class SomeClass
	{
		public string Status { get; set; }	
	}
