    public static class EnumerableExtensions
    {
        public static T MinBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, IComparer<TKey> comparer = null)
        {
            IEnumerator<T> etor = null;
    
            if (source == null || !(etor = source.GetEnumerator()).MoveNext())
                throw new ArgumentNullException("source");
            
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");
            
            var min = etor.Current;
            var minKey = keySelector(min);
    
            comparer = comparer ?? Comparer<TKey>.Default;
            while (etor.MoveNext())
            {
                var key = keySelector(etor.Current);
                if (comparer.Compare(key, minKey) < 0)
                {
                    min = etor.Current;
                    minKey = key;
                }
            }
    
            return min;
        }
    }
