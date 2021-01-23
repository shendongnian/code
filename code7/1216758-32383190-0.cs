    public static class Extensions
    {
    	public static IEnumerable<ObjectDependency> WhereContainsObjectVersion(this IEnumerable<ObjectDependency> source, int objectVersionId)
    	{
    		foreach (var item in source)
    		{
    			if (item.ObjectVersion1.Id == objectVersionId || item.ObjectVersion2.Id == objectVersionId)
    			{
    				yield return item;
    			}
    		}
    	}
    
    	public static IEnumerable<ObjectVersion> SelectDependentObjectVersions(this IEnumerable<ObjectDependency> source, int objectVersionId)
    	{
    		foreach (var item in source.WhereContainsObjectVersion(objectVersionId))
    		{
    			if (item.ObjectVersion1.Id == objectVersionId)
    			{
    				yield return item.ObjectVersion2;
    			}
    			else
    			{
    				yield return item.ObjectVersion1;
    			}
    		}
    	}
    
    	public static IEnumerable<TResult> SelectDependentObjectVersions<TResult>(this IEnumerable<ObjectDependency> source, int objectVersionId, Func<ObjectDependency, ObjectVersion, TResult> selector)
    	{
    		foreach (var item in source.WhereContainsObjectVersion(objectVersionId))
    		{
    			if (item.ObjectVersion1.Id == objectVersionId)
    			{
    				yield return selector(item, item.ObjectVersion2);
    			}
    			else
    			{
    				yield return selector(item, item.ObjectVersion1);
    			}
    		}
    	}
    
    	public static IEnumerable<ObjectVersion> SelectByLatestDistinctGenericObject(this IEnumerable<ObjectVersion> source)
    	{
    		return
    			source
    			.GroupBy(x => x.GenericObject.Id)
    			.Select(x => x.OrderByDescending(y => y.Id).FirstOrDefault());
    	}
    
    	public static IEnumerable<ObjectDependency> SelectByLatestDistinctGenericObject(this IEnumerable<ObjectDependency> source, int objectVersionId)
    	{
    		return
    			source
    			.SelectDependentObjectVersions(objectVersionId, (x, y) => new { ObjectDependency = x, ObjectVersion = y })
    			.GroupBy(x => x.ObjectVersion.GenericObject.Id)
    			.Select(x => x.OrderByDescending(y => y.ObjectVersion.Id).FirstOrDefault())
    			.Select(x => x.ObjectDependency);
    	}
    }
