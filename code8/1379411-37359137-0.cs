		var sums = new int[] { 12, 12, 12, 13, 13, 18 };
		var prods = new int[] { 67, 52, 60, 42, 17, 21 };
		var indexes = new int[] { 38, 107, 11, 98, 4, 60 };
		
		var grouped = indexes.Zip(sums, (first, second) => new { Index = first, Sum = second})
			.Zip(prods, (first, second) => new { Index = first.Index, Sum = first.Sum, Prod = second}).ToList();
		
		foreach (var group in grouped.OrderBy(g => g.Sum).ThenBy(g => g.Prod))
		{
			Console.WriteLine("{0}\t{1}\t{2}", group.Sum, group.Prod, group.Index);
		}	
