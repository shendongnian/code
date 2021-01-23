    public static class ExpandObjectExtensions
    {
    	public static TObject ConvertFromExpando<TObject>(this IDictionary<string, object> someSource, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public) where TObject : class, new ()
    	{
    		Contract.Requires(someSource != null);
    		TObject targetObject = new TObject();
    		Type targetObjectType = typeof (TObject);
    		foreach (PropertyInfo property in 
                      targetObjectType.GetProperties(bindingFlags))
    		{
    			if (someSource.ContainsKey(property.Name) 
                        && property.PropertyType == someSource[property.Name].GetType())
    			{
    				property.SetValue(targetObject, someSource[property.Name]);
    			}
    		}
    
    		return targetObject;
    	}
    }
