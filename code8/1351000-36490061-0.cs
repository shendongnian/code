    public static class LinqExtension
    {
        public static IOrderedEnumerable<TSource> OrderByAsc<TSource, TKey>(
    	this IEnumerable<TSource> source,
    	Expression<Func<T, object>> expression)
        {
    	    IEnumerable<TSource> newEnumerable = source;
    	    int ctr = 0;
         	NewArrayExpression array = expression.Body as NewArrayExpression;
            foreach( object obj in ( IEnumerable<object> )( array.Expressions ) )
            {
                 if(ctr == 0)
                 newEnumerable = newEnumerable
    				.OrderBy(item => item.GetType().GetProperty(obj.ToString()).GetValue(item, null));
                 else
                 newEnumerable = newEnumerable
    				.ThenBy(item => item.GetType().GetProperty(obj.ToString()).GetValue(item, null));
                 ctr++;
            }
    
    	    return newEnumerable;	   
        }
    
        public static IOrderedEnumerable<TSource> OrderByDesc<TSource, TKey>(
    	this IEnumerable<TSource> source,
    	Expression<Func<T, object>> expression)
        {
    	    IEnumerable<TSource> newEnumerable = source;
    	
         	NewArrayExpression array = expression.Body as NewArrayExpression;
            int ctr = 0;
            foreach( object obj in ( IEnumerable<object> )( array.Expressions ) )
            {
                 if(ctr == 0)
                 newEnumerable = newEnumerable
    				.OrderByDescending(item => item.GetType().GetProperty(obj.ToString()).GetValue(item, null));
                 else
                 newEnumerable = newEnumerable
    				.ThenByDescending(item => item.GetType().GetProperty(obj.ToString()).GetValue(item, null));
                 ctr++;
            }
    
    	    return newEnumerable;	   
        } 
    }
