	static void Exercise1()
	{
		Console.WriteLine("Enter minimum integer: ");
		int min = int.Parse(Console.ReadLine());
		Console.WriteLine("Enter maximum integer: ");
		int max = int.Parse(Console.ReadLine());
	
		IEnumerable<int> all = Enumerable.Range(min, max - min + 1);
		IEnumerable<int> odds = all.Where(n => n % 2 == 1);
		IEnumerable<int> evens = all.Where(n => n % 2 == 0);
	
		Console.WriteLine(String.Format("All: {0} = {1}", String.Join(" + ", all), all.Sum()));
		Console.WriteLine(String.Format("Odd: {0} = {1}", String.Join(" + ", odds), odds.Sum()));
		Console.WriteLine(String.Format("Even: {0} = {1}", String.Join(" + ", evens), evens.Sum()));
	}
