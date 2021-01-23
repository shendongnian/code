    public static void Main()
	{
		string[] files = 
            new string[] { "update_12345.log", "update_23456.log", "update_34567.log" };
				
        var sorted = files
          .Select(f => {var a = f.Split("_.".ToCharArray()); 
                        return new { name = f, number = a[1]};} )
          .OrderByDescending(fnn => Convert.ToInt64(fnn.number));
		// Print all
		sorted.ToList().ForEach(x => Console.WriteLine(x.name) );
        // Print Top 1 [1]
        Console.WriteLine(sorted.ToList().First().name);
        // Print Top 1 [2]
		Console.WriteLine(sorted.ToList().Take(1).Single().name);
	}
