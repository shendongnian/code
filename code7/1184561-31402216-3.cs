    var startDate = new DateTime(2015, 7, 1);
    var endDate = new DateTime(2015, 9, 1);
    var workDates = Enumerable.Range(0, (int)(endDate - startDate).TotalDays + 1)
        .Select(i => startDate.AddDays(i))
        .Where(date => (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday))
        .Select(i => i);
    
    
    var display = workDates
        .GroupAdjacentBy((x, y) => x.AddDays(1) == y)
        .Select(g => string.Format("Start: {0:dd/MMM/yyyy} End: {1:dd/MMM/yyyy}", g.First(), g.Last()));
    // Required extension
    public static class IEnumerableExtension
    {
    	public static IEnumerable<IEnumerable<T>> GroupAdjacentBy<T>(
    		this IEnumerable<T> source, Func<T, T, bool> predicate)
    	{
    		using (var e = source.GetEnumerator())
    		{
    			if (e.MoveNext())
    			{
    				var list = new List<T> { e.Current };
    				var pred = e.Current;
    				while (e.MoveNext())
    				{
    					if (predicate(pred, e.Current))
    					{
    						list.Add(e.Current);
    					}
    					else
    					{
    						yield return list;
    						list = new List<T> { e.Current };
    					}
    					pred = e.Current;
    				}
    				yield return list;
    			}
    		}
    	}
    }
