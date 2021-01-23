	var locationsFilter = locations.Select(location =>
	{
		var filter = PredicateUtils.Null<PropertyDetail>();
		if (!string.IsNullOrEmpty(location.Continent))
			filter = filter.And(d => d.Continent == location.Continent);
		if (!string.IsNullOrEmpty(location.Country))
			filter = filter.And(d => d.Country == location.Country);
		if (!string.IsNullOrEmpty(location.State))
			filter = filter.And(d => d.State == location.State);
		return filter;
	}).Aggregate(PredicateUtils.Or);
  
