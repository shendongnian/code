		var data = new[] { 'A', 'A', 'C', 'A', 'A', 'A', 'A', 'B', 'C', 'C' };
		
		var publishedData = data
			.ToObservable()
			.Publish()
			.RefCount();
		
		publishedData
			.GroupByUntil(e => e, e => e, g => publishedData.Where(i => i != g.Key))
			.Select(g => g.ToArray())
			.Merge()
			.Subscribe(groupedItems =>
			{
				Console.WriteLine("{0} - {1}", groupedItems.First(), groupedItems.Count());
			});
