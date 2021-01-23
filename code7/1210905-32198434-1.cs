	public static string Get_AreaID_Auto()
	{
		var existing = db.TESTs.Select(e => e.CAT_ID).OrderBy(x => x).ToList();
		if (existing.Count == 0)
		{
			return "C01";
		}
		else
		{
			return
				existing
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
	}
