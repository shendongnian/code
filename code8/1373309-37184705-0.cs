	var catId = 1;
	var query = new QueryContainer(new TermQuery { Field = "catId", Value = catId });
	query = query && new NumericRangeQuery { Field = "price", GreaterThan = 10 };
	var request = new SearchRequest<Project>("index-name", Types.Type(typeof(Project), typeof(AnotherProject)))
	{
		From = 0,
		Size = 100,
		Query = query,
		Sort = new List<ISort>
			{
				new SortField { Field = "field", Order = Nest.SortOrder.Descending },
            }
	};
	var response = client.Search<Project>(request);
