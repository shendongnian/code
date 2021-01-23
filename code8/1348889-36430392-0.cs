    public static IEnumerable<List<string>> Trim( this IEnumerable<List<string>> collection )
    {
    	foreach(var item in collection)
    	{
    		item.Trim();
    	}
    	return collection;
    }
