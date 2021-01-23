	private static Dictionary<string, object> WrapInDictionary(object value) 
	{
		return new Dictionary<string, object>()
		{
			{ value.GetType().Name, value }
		};
	}
