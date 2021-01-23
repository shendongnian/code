    public static class Extensions
    {
        public static IEnumerable<T> OrderedDistinct<T>(this IEnumerable<T> enumerable, IEqualityComparer<T> comparer)
        {
            HashSet<T> hash_set = new HashSet<T>(comparer);
            foreach(var item in enumerable)
                if (hash_set.Add(item))
                    yield return item;
        }
    }
