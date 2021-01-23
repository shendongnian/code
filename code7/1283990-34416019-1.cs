	var query =
		xss.Skip(1).Aggregate(
			xss.Take(1).ToList(),
			(yss, xs) =>
			{
				if (yss.All(ys => ys.Except(xs).SequenceEqual(ys)))
				{
					yss.Add(xs);
				}
				return yss;
			});
