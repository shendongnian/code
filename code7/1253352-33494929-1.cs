	// Plain query, not doing subqueries. Unfortunately brings extra rows in memory.
	var q =
		from app in ctx.Applications
		join s in ctx.SubObjectsOne on app.Id equals s.AppId into joinedSubObjectOne
		from subObjectOne in joinedSubObjectOne.DefaultIfEmpty()
		where subObjectOne.SomeProperty == 0 // additional sub object criteria
		select new { app, subObjectOne };
	var l = q.ToList();
	// From now on objects are materialized, doing the rest in memory:
	var translated =
		from i in l
		group i by i.app.Id into g
		select new
		{
			app = g.First().app,
			// This is expensive too, but not doing separate db requests.
			SubObjectOneByMaxProperty = g.Select(i => i.subObjectOne).OrderByDescending(s => s.SomeOrder).FirstOrDefault()
		};
	var translatedList = translated.ToList();
