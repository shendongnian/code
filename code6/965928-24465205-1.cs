	Func<
		IEnumerable<IEnumerable<char>>,
		IEnumerable<char>,
		IEnumerable<IEnumerable<char>>> f = null;
	f = (css, cs) =>
	{
		if (!cs.Any())
		{
			return css;
		}
		else
		{
			return f(css
				.SelectMany(
					x => keys[cs.First()],
					(x, k) => x.Concat(new [] { k })),
				cs.Skip(1));
		}
	};
	
