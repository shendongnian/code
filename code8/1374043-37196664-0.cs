    public static class EnumUtil
    {
        public static IEnumerable<T> GetValues<T>()
	    {
		    foreach(T enumVal in Enum.GetValues(typeof(T)))
    		{
	            yield return enumVal;
    		}
    	}
    } 
