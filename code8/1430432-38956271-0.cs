	var projectionParameter = Expression.Parameter(typeof(IGrouping<int, Communication>), "group");
	var projectionType = typeof(SeriesProjection);
	var projectionBody = Expression.MemberInit(
		// new SeriesProjection
		Expression.New(projectionType),
		// {
		//     Count = group.Count(),
		Expression.Bind(
			projectionType.GetProperty(nameof(SeriesProjection.Count)),
			Expression.Call(typeof(Enumerable), "Count", new[] { typeof(Communication) }, projectionParameter)),
		//     Id = group.Key
		Expression.Bind(
			projectionType.GetProperty(nameof(SeriesProjection.Id)),
			Expression.Property(projectionParameter, "Key")),
		//     Name = group.FirstOrDefault().Property
		Expression.Bind(
			projectionType.GetProperty(nameof(SeriesProjection.Name)),
			Expression.Property(
				Expression.Call(typeof(Enumerable), "FirstOrDefault", new[] { typeof(Communication) }, projectionParameter),
				prop.Name))
		// }
		);
	var projectionSelector = Expression.Lambda<Func<IGrouping<int, Communication>, SeriesProjection>>(projectionBody, projectionParameter);
