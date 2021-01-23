	var requests = GetExternalRequests().ToList();
	
	var result = requests.GroupBy(g => g.PersonId)
		.Select(g => g.OrderBy (r => r.Start)
		.Aggregate(new List<Request>(), 
			(acc, right) => {
            if (acc.Count > 0)
			{
				var lastItem = acc[acc.Count - 1];
				if (lastItem.Intersects(right))
				{
					lastItem.Merge(right);
					return acc;
				}
			}
			acc.Add(right);
			return acc;
		}));
