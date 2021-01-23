    void Main()
    {
       var list=new int []{1,2,3,4};
       var query=from l in Listings.WhereIf(ListHasElements(list),s=>list.Contains(s.Id))
       select l;
       query.Dump();
    }
    public bool ListHasElements<T>(IEnumerable<T> it)
    {
    	return it.Any();
    }
    
    public static class Ext {
    	public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition,
    		Expression<Func<TSource, bool>> predicate)
    	{
    		return condition ? source.Where(predicate) : source;
    	}
    }
