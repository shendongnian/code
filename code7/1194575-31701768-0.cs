    public static class Extensions
    {
    	public static void AddNested<TOuter, TInner>(
    		this IEnumerable<TOuter> outerItems,
    		Func<TOuter, ICollection<TInner>> innerCollectionSelector,
    		Func<TOuter, bool> outerPredicate,
    		Func<TOuter, TInner> innerProducer
    	)
    	{
    		foreach(var outer in outerItems)
    		{
    			innerCollectionSelector(outer).Add(innerProducer(outer));
    		}
    	}
    	
    	public static void AddNested<TOuter, TInner>(
    		this IEnumerable<TOuter> outerItems,
    		Func<TOuter, ICollection<TInner>> innerCollectionSelector,
    		Func<TOuter, bool> outerPredicate,
    		TInner innerItemToAdd
    	)
    	{
    		outerItems.AddNested(innerCollectionSelector, outerPredicate, _ => innerItemToAdd);
    	}
    	
    	public static void AddNested<TOuter, TInner>(
    		this IEnumerable<TOuter> outerItems,
    		Func<TOuter, ICollection<TInner>> innerCollectionSelector,
    		TOuter outerItem,
    		Func<TOuter, TInner> innerProducer
    	)
    	{
    		outerItems.AddNested(innerCollectionSelector, i => i.Equals(outerItem), innerProducer);
    	}
    	
    	public static void AddNested<TOuter, TInner>(
    		this IEnumerable<TOuter> outerItems,
    		Func<TOuter, ICollection<TInner>> innerCollectionSelector,
    		TOuter outerItem,
    		TInner innerItemToAdd
    	)
    	{
    		outerItems.AddNested(innerCollectionSelector, outerItem, _ => innerItemToAdd);
    	}
    }
