	var types = GetType().Assembly.GetTypes()
	.Select(t => new
	{
		Type = t,
		MatchingInterfaces = t.GetInterfaces()
                              .Where(i => i.GetGenericTypeDefinition() == typeof(IRead<>))
	})
	.Where(t => t.MatchingInterfaces.Any())
