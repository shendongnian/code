    public static List<T> AssembleItem<T>(DataTable dtItems) where T : new()
    {
    	List<T> items = null;
    	if (dtItems != null)
    	{
    		items = new List<T>();
    		foreach (DataRow dr in dtItems.Rows)
    		{
    			T item = new T();
    			foreach (DataRow dr in dtItems.Rows)
    			{
    				T item = new T();
    
    				Type t = typeof (T);
    				foreach (var property in t.GetProperties(BindingFlags.Public))
    				{
    					var propertyname = property.Name;
    
    					//var data = ...get data from row in database with same column name as   propertyname
    
    					property.SetValue(item,data);
    				}
    				// populate item from dr
    				items.Add(item);
    			}
    		}
    		return items;
    	}
    }
