    internal class Program
    {
    	private class Reed<T>
    	{
    		private IDictionary<String, IList<T>> filters;
    		public void SetFilters(String key, params T[] values)
    		{
    			if (key == null || values == null)
    			{
    				throw new ArgumentNullException("Must have filter name and values.");
    			}
    
    			if (filters == null)
    				filters = new Dictionary<String, IList<T>>();
    			IList<T> fvalues = values.ToList();
    			filters.Add(key, fvalues);
    		}
    	}
    
    	private static void Main(string[] args)
    	{
    		var r1 = new Reed<string>();
    		r1.SetFilters("test", "one", "two", "three");
    		var r2 = new Reed<int>();
    		r2.SetFilters("test", 1, 2, 3);
    	}
    }
