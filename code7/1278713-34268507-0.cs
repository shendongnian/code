	public static IEnumerable<ObjectWithPriority> CreateObjectsWithPriorities()
	{
		var objs = new[] { 1, 2, 3 }.Select(i => new ObjectWithPriority() { Id = i })
									.ToList();
		ApplyPriorities(objs);
		return objs;
	}
