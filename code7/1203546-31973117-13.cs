    public static class Extension
    {
    	public static IEnumerable<IDeletable> Where(this IEnumerable<IDeletable> source, 
            Func<IDeletable, bool> predicate)
    	{
    		return System.Linq.Enumerable.Where(source, (x => predicate(x) && !x.IsDeleted));
    	}
    }
