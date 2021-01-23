    public static class Extension
    {
    	public static IEnumerable<IsDeletable> Where<IsDeletable>(this IEnumerable<IsDeletable> source, Func<IsDeletable, bool> predicate)
    	{
    		return source.Where(x => !x.IsDeleted).Where(predicate);
    	}
    } 
