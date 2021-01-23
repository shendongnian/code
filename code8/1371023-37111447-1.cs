    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ConditionalWhere<T>(this IEnumerable<T> list, 
                                                   bool condition, Func<T,bool> predicate)
        {
            if(!condition)
                 return list;
            return list.Where(predicate);
        }
    }
