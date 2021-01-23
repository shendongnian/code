	var ordered = ranges.OrderBy(x => x.Start).ThenBy(x => x.End).ToArray();
	
	var working =
		ordered
			.Skip(1)
			.Aggregate(new
			{
				contiguous = new List<DateRange>(),
				current = ordered.First(),
			}, (a, r) =>
			{
				if (a.current.End >= r.Start)
				{
					return new
					{
						a.contiguous,
						current = r.End > a.current.End
							? new DateRange(a.current.Start, r.End)
							: a.current,
					};
				}
				else
				{
					a.contiguous.Add(a.current);
					return new
					{
						a.contiguous,
						current = r,
					};
				}
			});
			
	var results = working.contiguous;
	results.Add(working.current);
