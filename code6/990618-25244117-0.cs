	private static IQueryContainer CreateQueryFromFilter(ProductFilter filter)
	{
		QueryContainer queryContainer = null;
		if (filter.IncludeNames != null && filter.IncludeNames.Length > 0)
		{
			foreach (var include in filter.IncludeNames)
			{
				//using object initializer syntax
				queryContainer &= new TermQuery()
				{
					Field = Property.Path<Product>(p => p.Name),
					Value = include
				};
			}
		}
		if (filter.ExcludeNames != null && filter.ExcludeNames.Length > 0)
		{
			foreach (var exclude in filter.ExcludeNames)
			{
				//using static Query<T> to dispatch fluent syntax
				//note the ! support here to introduce a must_not clause
				queryContainer &= !Query<Product>.Term(p => p.Name, exclude);
			}
		}
		if (filter.MaxPrice > 0)
		{
			//fluent syntax through manually newing a descriptor
			queryContainer &= new QueryDescriptor<Product>()
				.Range(r => r.LowerOrEquals(filter.MaxPrice).OnField(f => f.Price)
			);
		}
		return queryContainer;
	}
