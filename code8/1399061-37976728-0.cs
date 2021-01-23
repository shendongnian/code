    namespace MyLinq
    {
    	public static class Extensions
    	{
    		public static IOrderedEnumerable<T> Where<T>(this IOrderedEnumerable<T> source, Func<T, bool> predicate)
    		{
    			return new WhereOrderedEnumerable<T>(source, predicate);
    		}
    
    		class WhereOrderedEnumerable<T> : IOrderedEnumerable<T>
    		{
    			readonly IOrderedEnumerable<T> source;
    			readonly Func<T, bool> predicate;
    			public WhereOrderedEnumerable(IOrderedEnumerable<T> source, Func<T, bool> predicate)
    			{
    				if (source == null) throw new ArgumentNullException(nameof(source));
    				if (predicate == null) throw new ArgumentNullException(nameof(predicate));
    				this.source = source;
    				this.predicate = predicate;
    			}
    			public IOrderedEnumerable<T> CreateOrderedEnumerable<TKey>(Func<T, TKey> keySelector, IComparer<TKey> comparer, bool descending) =>
    				new WhereOrderedEnumerable<T>(source.CreateOrderedEnumerable(keySelector, comparer, descending), predicate);
    			public IEnumerator<T> GetEnumerator() => Enumerable.Where(source, predicate).GetEnumerator();
    			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    		}
    	}
    }
