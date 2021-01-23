    public static TSource MaxBy<TSource, TProperty>(this IEnumerable<TSource> source,
        Func<TSource, TProperty> selector)
    {
        // check args        
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())            
                throw new InvalidOperationException();
            
            var max = iterator.Current; 
            var maxValue = selector(max);
            var comparer = Comparer<TProperty>.Default;
            while (iterator.MoveNext())
            {
                var current = iterator.Current;
                var currentValue = selector(current);
                if (comparer.Compare(currentValue, maxValue) > 0)
                {
                    max = current;
                    maxValue = currentValue;
                }
            }
            return max;
        }
    }
