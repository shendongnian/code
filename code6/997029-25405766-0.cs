    public class Foo
    {
    	public IDictionary<String, IList> filters;
    	public void SetFilters(String key, params object[] values)
    	{
    		if (key == null || values == null)
    		{
    			throw new ArgumentNullException("Must have filter name and values.");
    		}
    
    		if (filters == null)
            {
			    filters = new Dictionary<String, IList>();
            }
    		IList fvalues = values.ToList();
    		filters.Add(key, fvalues);
    	}
    }
