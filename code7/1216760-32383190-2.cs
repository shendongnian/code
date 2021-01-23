    public static class Extensions
    {
    	public static IQueryable<ObjectDependency> WhereContainsObjectVersion(this IQueryable<ObjectDependency> source, int objectVersionId)
    	{
    		return
    			source
    			.Where(x => x.ObjectVersion1.Id == objectVersionId || x.ObjectVersion2.Id == objectVersionId);
    	}
    
    	public static IQueryable<ObjectVersion> SelectDependentObjectVersions(this IQueryable<ObjectDependency> source, int objectVersionId)
    	{
    		return
    			source
    			.WhereContainsObjectVersion(objectVersionId)
    			.Select(x => x.ObjectVersion1.Id == objectVersionId ? x.ObjectVersion2 : x.ObjectVersion1);
    	}
    
    	public static IQueryable<TResult> SelectDependentObjectVersions<TResult>(this IQueryable<ObjectDependency> source, int objectVersionId, Func<ObjectDependency, ObjectVersion, TResult> selector)
    	{
    		return
    			source
    			.WhereContainsObjectVersion(objectVersionId)
    			.Select(x => x.ObjectVersion1.Id == objectVersionId ? selector(x, x.ObjectVersion2) : selector(x, x.ObjectVersion1));
    	}
    
    	public static IQueryable<ObjectVersion> SelectByLatestDistinctGenericObject(this IQueryable<ObjectVersion> source)
    	{
    		return
    			source
    			.GroupBy(x => x.GenericObject.Id)
    			.Select(x => x.OrderByDescending(y => y.Id).FirstOrDefault());
    	}
    
    	public static IQueryable<ObjectDependency> SelectByLatestDistinctGenericObject(this IQueryable<ObjectDependency> source, int objectVersionId)
    	{
    		return
    			source
    			.SelectDependentObjectVersions(objectVersionId, (x, y) => new { ObjectDependency = x, ObjectVersion = y })
    			.GroupBy(x => x.ObjectVersion.GenericObject.Id)
    			.Select(x => x.OrderByDescending(y => y.ObjectVersion.Id).FirstOrDefault())
    			.Select(x => x.ObjectDependency);
    	}
    }
