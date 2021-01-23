    public static IEnumerable<IConvertible> AsConvertible<T>(this IEnumerable<T> source)
        where T : IConvertible
    {
    	return source as IEnumerable<IConvertible> ?? source.Select(item => (IConvertible)item);
    }
    
    public static IEnumerable<TResult> ConvertTo<TResult>(this IEnumerable<IConvertible> source)
    {
    	return source as IEnumerable<TResult> ?? 
    	    source.Select(item => (TResult)Convert.ChangeType(item, typeof(TResult)));
    }
