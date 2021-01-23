    static class MyConcatExtension
    {
        public static IEnumerable<T> ConcatNotNulls<T>(this IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            // collection is null, you might want to check collection1 as well
            if (collection2 == null)
            {
                return collection1;
            }
            // collection of reference types has null items 
            if (!typeof(T).IsValueType)
            {
                return collection1.Concat(collection2.Where(item => item != null));
            }
            // collection of value types
            return collection1.Concat(collection2);
        }
    }
