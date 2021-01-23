    public static class EnumerableObject
    {
        // Enumerates "a little" the source to discover the type. Then
        // recreates another IEnumerable<> with the same objects. Does it in
        // O(1) memory (so doesn't create a List<> or a T[])
        public static IEnumerable<object> GetType(this IEnumerable<object> source, out Type type)
        {
            type = typeof(object);
            IEnumerator<object> enu;
            enu = source.GetEnumerator();
            try
            {
                // The number of "starting nulls"
                int nulls = 0;
                bool success;
                object current = null;
                while (success = enu.MoveNext())
                {
                    current = enu.Current;
                    if (current == null)
                    {
                        nulls++;
                    }
                    else
                    {
                        type = current.GetType();
                        break;
                    }
                }
                return enu.GetTypeImpl(nulls, success, current);
            }
            catch
            {
                enu.Dispose();
                throw;
            }
        }
        private static IEnumerable<object> GetTypeImpl(this IEnumerator<object> enu, int nulls, bool success, object current)
        {
            using (enu)
            {
                // First return the "starting nulls"
                for (int i = 0; i < nulls; i++)
                {
                    yield return null;
                }
                // If the last MoveNext was a success, then 
                if (success)
                {
                    // first return current
                    yield return current;
                    // then continue returning other items
                    while (enu.MoveNext())
                    {
                        yield return enu.Current;
                    }
                }
            }
        }
        public static IEnumerable<TSource> FilterByUniqueProp<TSource>
                (this IEnumerable<TSource> query, TSource model)
        {
            // Do something accourding to this type
            var type = typeof(TSource);
            return null;
        }
        public static IEnumerable<TSource> FilterByUniqueProp2<TSource>(this IEnumerable<object> query, TSource model)
        {
            // We use Cast<>() to conver the IEnumerable<>
            return query.Cast<TSource>().FilterByUniqueProp<TSource>(model);
        }
    }
