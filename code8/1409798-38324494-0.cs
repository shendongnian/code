    public static class MyExtensions
    {
        public static IEnumerable<K> MySelect<T, K>(this IEnumerable<T> source, 
                                                                          Func<T, K> selector)
        {
            foreach(T item in source)
            {
                yield return selector(item);
            }
        }
            
        public static IEnumerable<K> MySelect2<T, K>(this IEnumerable<T> source, 
                                                                         string propertyName)
        {
                
            foreach (T item in source)
            {
                // K value = GET VALUE BY REFLECTION HERE THROUGH T AND PROPERTY NAME;
                yield return value;
            }
        }
    }
