    public static class ObjEx
    {
    	public static string ToQueryString(this object data)
    	{
    		var collection = data.GetType()
                .GetProperties()
                .Aggregate(
                    HttpUtility.ParseQueryString(string.Empty),
                    (prev,curr) => {
    			        var val = curr.GetValue(data);
    			        var propName = curr.Name;
    			        prev.Add(propName,val.ToString());
    			        return prev;
    		    });
    		return collection.ToString();
    	}
    }
