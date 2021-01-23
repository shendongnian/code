    public interface IDeletable
    {
    	bool IsDeleted { get; set; }
    }
    
    public static class Extension
    {
    	public static IEnumerable<T> WhereNotDeleted<T>(this IEnumerable<T> source, 
            Func<T, bool> predicate) where T : IDeletable
    	{
    		return source.Where(x => !x.IsDeleted).Where(predicate);
    	}
    }
