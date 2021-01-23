    using System.Collections.Generic;
    using System.Linq;
    
    static class ExtMethods
    {
    	public static IEnumerable<TResult> SelectTwo<TSource, TResult>(this IEnumerable<TSource> source,
                                                                            Func<TSource, TSource, TResult> selector)
        {
        	return Enumerable.Zip(source, source.Skip(1), selector);
        }
    }
