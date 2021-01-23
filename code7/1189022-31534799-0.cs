	var source = new [] { 1,1,2,5,8,1,9,1,2 };
	Func<int[], int[], bool> contains =
		(xs, ys) =>
			Enumerable
				.Range(0, xs.Length)
				.Where(n => xs.Skip(n).Take(ys.Length).SequenceEqual(ys))
				.Any();
				
	Console.WriteLine(contains(source, new [] { 2,5,8,1,9 })); // true
	Console.WriteLine(contains(source, new [] { 1,2,5,8,1 })); // true
	Console.WriteLine(contains(source, new [] { 5,2,1 })); // false
	Console.WriteLine(contains(source, new [] { 1,2,5,1,8 })); // false
	Console.WriteLine(contains(source, new [] { 1,1,2 })); // true
	Console.WriteLine(contains(source, new [] { 1,1,1,2 })); // false
