    public static class JsonExtensions
    {
    	public static T Pop<T>(this JArray jArray)
    	{
    		T obj = default(T);
    		if (jArray.Count > 0)
    		{
    			obj = jArray[0].ToObject<T>();
    			jArray.RemoveAt(0);
    		}
    		return obj;
    	}
    }
