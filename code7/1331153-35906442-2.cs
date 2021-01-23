    public static void Main()
	{
		string[] files = 
            new string[] { "update_12345.log", "update_23456.log", "update_34567.log" };
		
		
        var sorted = files.Select(f =>{var a = f.Split("_.".ToCharArray()); return new {a = f, b = a[0], c = a[1]};} ).
            OrderByDescending(abc=>Convert.ToInt64(abc.c));
		// Print all
		sorted.ToList().ForEach(abc => Console.WriteLine(abc.a) );
        // Print Top 1 [1]
        Console.WriteLine(sorted.ToList().First().a);
        // Print Top 1 [2]
		Console.WriteLine(sorted.ToList().Take(1).Single().a);
	}
