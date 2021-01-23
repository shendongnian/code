    public static class TestClass
    {
    	public static IEnumerable<TReturnType> DoSelect<TSourceType, TReturnType>(this IEnumerable<TSourceType> source, Func<TSourceType, int, TReturnType> action)
    	{
    		int i = 0;
    		foreach(var row in source)
    			yield return action(row, i++);
    	}
    }
