    public static class LinqExtensions
    {
    	public static ErrorCode BusinessSingle(this IEnumerable<TSource> enumerable, Func<TSource, bool> predicate)
    	{
    		TSource result;
    
    		try
    		{
    			result = enumerable.Single(predicate);
    
    			return new NoError(); // ????
    		}
    		catch
    		{
    			return new ErrorOne();
    		}
    	}
    
    }
