    public static bool AreAllStringsEmpty(params string[] array)
	{
		return array.Any(str => String.IsNullOrWhiteSpace(str));
	}
	
	public static bool AreAllStringsFull(params string[] array)
	{
		return array.All(str => !String.IsNullOrWhiteSpace(str));
	}
