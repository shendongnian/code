	var inputs = new List<IEnumerable<int>>
	{
		new List<int>{ 4,5,2,6,8,4,5,6,5,6,8,9,9 },
		new List<int>{ 1,2,3 },
		new List<int>{ 1,2,4 },
	};
	
	foreach(var input in inputs)
	{
		var result = input.Aggregate(Enumerable.Empty<int>(), 
						(agg, cur) => agg.Count() == 3 ? agg
										: agg.Any() && cur == agg.Last() + 1
											? agg.Concat(new []{cur})
											: new []{cur});
											
		Console.WriteLine(result.Count() >= 3 ? String.Join(", ", result) : "not found");
	}
