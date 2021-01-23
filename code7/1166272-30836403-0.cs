	public static bool IsContainedWithin(this string @this, string container)
	{
		var lookup = container.ToLookup(c => c);
		return @this.ToLookup(c => c).All(c => lookup[c.Key].Count() >= c.Count());
	}
