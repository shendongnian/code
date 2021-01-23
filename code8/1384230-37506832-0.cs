    public static class Helper
    {
    	public static TReturnType Elvis<TOnType, TReturnType>(this TOnType onObj, Func<TOnType, TReturnType> selector)
    		where TReturnType : class
    	{
    		if (onObj == null)
    			return null;
    		return selector(onObj);
    	}
    }
