	public static T GetFirstWithMessage<T>(this IEnumerable<T> collection, 
                                           Func<T, bool> matchFunc, 
                                           out string outputString, 
                                           string message) 
	{
		var match = collection.FirstOrDefault(matchFunc);
		outputString = match == null ? null : message;
		return match;
	}
