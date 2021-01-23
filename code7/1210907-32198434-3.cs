	public static string Get_AreaID_Auto()
	{
		return
			db.TESTs
				.Select(e => e.CAT_ID)
				.OrderBy(x => x)
				.ToArray()
				.Concat(new [] { "" })
				.Select((x, n) => new
				{
					actual = x,
					expected = String.Format("C{0:00}", n + 1),
				})
				.Where(x => x.actual != x.expected)
				.Select(x => x.expected)
				.First();
	}
