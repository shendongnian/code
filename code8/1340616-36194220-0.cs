	Func<IEnumerable<string>, IEnumerable<string>> expand = null;
	expand = xs =>
	{
		if (xs != null && xs.Any())
		{
			var head = xs.First();
			if (xs.Skip(1).Any())
			{
				return expand(xs.Skip(1)).SelectMany(tail => new []
				{
					head + tail,
					head + "-" + tail
				});
			}
			else
			{
				return new [] { head };
			}
		}
		else
		{
			return Enumerable.Empty<string>();
		}
	};
	var keyword = "A-B-C-D";
	
	var parts = keyword.Split('-');
	var results = expand(parts);
