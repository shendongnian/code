		var aggregateByLength =
			results
				.SelectMany(fi => fi)
				.Aggregate(new [] { new StringBuilder() }.ToList(),
					(sbs, s) =>
					{
						var nl = s + Environment.NewLine;
						if (sbs.Last().Length + nl.Length > maxSz)
						{
							sbs.Add(new StringBuilder(nl));
						}
						else
						{
							sbs.Last().Append(nl);
						}
						return sbs;
					});
