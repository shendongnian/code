	var periods = Periods
		.Select(p => new {
				p = p,
				a = p.StartingDate.Year*12 + p.StartingDate.Month - 1,
				b = p.EndingDate.Year*12 + p.EndingDate.Month
			}
		)
		.Select(x => new {
			period = x.p,
			subperiods =
				Enumerable
				.Range(x.a, x.b - x.a)
				.Select(e => new DateTime(e/12, e%12 + 1, 1))
				.Where(d => StartingMonth <= d.Month && d.Month <= EndingMonth)
				.GroupBy(i => i.Year)
				.Where(g => g.Count() > 1)
				.Select(g => new Period {
					StartingDate = g.Min(),
					EndingDate = g.Max()
				})
				.Select(p => new Period {
					StartingDate = p.StartingDate < x.p.StartingDate ? x.p.StartingDate : p.StartingDate,
					EndingDate = (p.EndingDate > x.p.EndingDate ? x.p.EndingDate : p.EndingDate)
						.AddMonths(1)
						.AddDays(-1)
				})
			});
