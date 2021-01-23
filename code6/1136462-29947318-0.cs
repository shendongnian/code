    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public static partial class ExtHelper
    {
    	public static Dictionary<T, W[]> GroupEqualsInObjects<T, U, W>(this U[] items, Func<U, T[]> funcVariables, Func<U, int, W> funcValues)
    	{
    		Dictionary<T, W[]> MatchingItems = items
    		.SelectMany(c => funcVariables(c)
    		.Select((t, i) => new {key = t, item = funcValues(c, i)})
    		.ToDictionary(x => x.key, y => y.item))
    		.GroupBy(t => t.Key)
    		.ToDictionary(t => t.Key, t => t.Select(c => c.Value).ToArray());
    
    		return MatchingItems;
    	}
    }
