	Action<IEnumerable<CompositeType>, Func<CompositeType, int>, Action<CompositeType, int>> compute =
		(cs, f, a) =>
		{
			var stats =
				from c in cs
				group c by f(c) into gs
				orderby gs.Key
				select new
				{
					Stats = gs.Key,
					Participants = gs.ToList()
				};
		
			stats.Aggregate(0, (points, statGroup) =>
			{
				var maxPoints = points + statGroup.Participants.Count * 2 - 2;
				statGroup.Participants.ForEach(c => a(c, points));
				return maxPoints + 2;
			});
		};
