    public static class ExpandObjectExtensions
    {
    	public static TObject ToObject<TObject>(this IDictionary<string, object> someSource, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public)where TObject : class, new ()
    	{
    		Contract.Requires(someSource != null);
    		TObject targetObject = new TObject();
    		Type targetObjectType = typeof (TObject);
    		
    		// Go through all bound target object type properties...
    		foreach (PropertyInfo property in 
    				 	targetObjectType.GetProperties(bindingFlags))
    		{
    			// ...and check that both the target type property name and its type matches
    			// its counterpart in the ExpandoObject
    			if (someSource.ContainsKey(property.Name) 
    				&& property.PropertyType == someSource[property.Name].GetType())
    			{
    				property.SetValue(targetObject, someSource[property.Name]);
    			}
    		}
    
    		return targetObject;
    	}
    }
