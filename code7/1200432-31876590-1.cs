	public static class ExtensionMethods
	{
		public static IQueryable<T> FilterCollectors<T>(this IQueryable<T> collectors, SomeObject d)
			where T : ICollectorTable
		{
			if (d.NId.Count() != 0)
				collectors = collectors.Where(x => d.NId.Contains(x.NId));
			if (d.PId.Count() != 0)
				collectors = collectors.Where(x => d.PId.Contains(x.PId ?? -1));
			if (d.BId.Count() != 0)
				collectors = collectors.Where(x => d.BId.Contains(x.BId ?? -1));
			return collectors;
		}
	}
