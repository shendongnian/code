	var query =
		TableCs.SelectMany(c => c.TableA.TableBs
			.Where(b => b.Col5 == "SomeValue"
				// && ...
			),
			(c, b) => new { c, b }
		)
		.GroupBy(r => new { r.c.Col2, r.c.Col3, r.b.Col5 })
		.Select(g => new
		{
			g.Key.Col2,
			g.Key.Col3,
			g.Key.Col5,
			SomeColumnC = g.Sum(r => r.c.SomeColumn),
            SomeColumnB = g.Sum(r => r.b.SomeColumn)
			// ...
		});
