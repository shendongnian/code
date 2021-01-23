    public static class Test
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            Contract.Requires(source != null);
            Contract.Requires(predicate != null);
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
    
    // This throws a contract exception directly, no need of 
    // enumerating the returned enumerable
    Test.Where<string>(null, null);
    
