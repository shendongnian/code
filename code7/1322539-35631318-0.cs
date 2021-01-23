    public class GroupResult<T>
    {
    	public object Key { get; set; }
    	public int Count { get; set; }
    	public IEnumerable<T> Items { get; set; }
    	public IEnumerable<GroupResult<T>> SubGroups { get; set; }
    	public override string ToString() { return string.Format("{0} ({1})", Key, Count); }
    }
    
    public static class MyEnumerableExtensions
    {
    	public static IEnumerable<GroupResult<TElement>> GroupByMany<TElement>(
    		this IEnumerable<TElement> elements,
    		params Func<TElement, object>[] groupSelectors)
    	{
    		Func<IEnumerable<TElement>, IEnumerable<GroupResult<TElement>>> groupBy = source => null;
    		for (int i = groupSelectors.Length - 1; i >= 0; i--)
    		{
    			var keySelector = groupSelectors[i]; // Capture
    			var subGroupsSelector = groupBy; // Capture
    			groupBy = source => source.GroupBy(keySelector).Select(g => new GroupResult<TElement>
    			{
    				Key = g.Key,
    				Count = g.Count(),
    				Items = g,
    				SubGroups = subGroupsSelector(g)
    			});
    		}
    		return groupBy(elements);
    	}
    }
