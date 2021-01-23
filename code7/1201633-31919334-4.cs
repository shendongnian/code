	public static int TryGetBIdWithMaxOccur(this IEnumerable<A> input, SelectedTypeEnum selectedType)
	{
		var result = input
			.SelectMany(x => x.B)
			.Where(x => x.Type == selectedType)
			.GroupBy(x => x.Id, new { Id = x.Key, Count = x.Count() })
			.OrderByDescending(x => x.Count)
            .Select(x => x.Id)
			.FirstOrDefault();
	
		return result;
	}
	
