	void Main()
	{
		var queryInfo = new DomainQuery();
		var ContentList = new List<Content>();
		
		var query = ContentList
			.Where(q=>queryInfo.PhrasesIncludeAny
				.Any(item=>q.Summary.Any(subitem=>subitem == item)))
			.Where(q=>queryInfo.PhrasesIncludeAll
				.All(item=>q.Summary.All(subitem=>subitem == item)))
			.Where(q=>!queryInfo.PhrasesIncludeAll
				.All(item=>q.Summary.All(subitem=>subitem == item)))
			.Where(q=>q.CreatedDate < queryInfo.CreatedBefore)
			.Where(q=>q.CreatedDate > queryInfo.CreatedAfter);
		
	}
