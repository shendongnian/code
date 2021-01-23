	public IEnumerable<string> Combinations(int n)
	{
		return Fracture(n.ToString())
			.Select(x => x.Select(y => int.Parse(y) + 'a' - 1))
			.Where(x => x.All(y => y >= 'a' && y <= 'z'))
			.Select(x => String.Join("", x.Select(y => (char)y)));
	}
	
	public IEnumerable<IEnumerable<string>> Fracture(string x)
	{
		return String.IsNullOrEmpty(x)
			? new [] { Enumerable.Empty<string>() }
			: Enumerable
				.Range(1, x.Length)
				.SelectMany(y =>
					Fracture(x.Substring(y))
					.Select(z =>
						new [] { x.Substring(0, y) }
							.Concat(z)));
	}
