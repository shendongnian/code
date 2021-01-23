	var input = new[]
	{
		new List<double> { 1.1, 1.2 },
		new List<double> { 2.1, 2.2, 2.3, 2.4 },
		new List<double> { 3.1, 3.2 },
		new List<double> { 4.1, 4.2 },
		...
	};            
	var output = input.Aggregate((IEnumerable<IEnumerable<double>>)new[] { new double[0] }, (combos, values) =>
		values.SelectMany(value => combos.Select(combo =>
			combo.Concat(new[] { value }))));
	foreach (var combo in output)
	{
		Console.WriteLine(string.Join(", ", combination));
	}
