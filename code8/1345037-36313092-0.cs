    public static T UpdateClone<T>(T obj)
    {
	    var newObj = obj;
    	foreach (PropertyInfo p in obj.GetType().BaseType.GetProperties())
	    {
     		if (p.Name.ToString().ToLower() == "id")
    		{
	    		p.SetValue(newObj, Guid.NewGuid());
    		}
	    }
    	foreach (PropertyInfo pInfo in obj.GetType().GetProperties())
    	{
	    	var propertyObject = pInfo.GetValue(obj);
    		if (propertyObject != null)
    		{
    			if (propertyObject is IEnumerable && !(propertyObject is string))
    			{
	    			foreach (object p in (propertyObject as IEnumerable))
		    		{
			    		UpdateClone(p);
	    			}
	    		}
    			else
    			{
	    			foreach (PropertyInfo p in propertyObject.GetType().BaseType.GetProperties())
		    		{
			    		if (p.Name.ToString().ToLower() == "id")
			    		{
			    			p.SetValue(propertyObject, Guid.NewGuid());
			    		}
			    	}
		    	}
	    	}
	    }
	  return newObj;
    }
