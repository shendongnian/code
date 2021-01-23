    public static class PolymorphicEnumerableExtensions
    {
        public static IEnumerable<KeyValuePair<int, TResult>> OfIndexAndType<TResult>(this IEnumerable source)
        {
            if (source == null)
                throw new ArgumentNullException();
            return OfIndexAndTypeIterator<TResult>(source);
        }
        static IEnumerable<KeyValuePair<int, TResult>> OfIndexAndTypeIterator<TResult>(IEnumerable source)
        {
            int i = 0;
            foreach (object obj in source)
            {
                if (obj is TResult) 
                    yield return new KeyValuePair<int, TResult>(i, (TResult)obj);
                i++;
            }
        }
    }
