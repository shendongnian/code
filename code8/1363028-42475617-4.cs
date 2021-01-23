	public static void DetachLocal<T>(this DbContext context, T t, string entryId) 
		where T : class, IIdentifier 
	{
		var local = context.Set<T>()
			.Local
			.FirstOrDefault(entry => entry.Id.Equals(entryId));
		if (!local.IsNull())
		{
			context.Entry(local).State = EntityState.Detached;
		}
		context.Entry(t).State = EntityState.Modified;
	}
