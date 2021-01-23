    public static class ICollectionExtensions
    {
        public static IEnumerable<TSource> SortLike<TSource,TKey>(this ICollection<TSource> source, 
                                            IEnumerable<TKey> sortOrder)
        {
            var cloned = sortOrder.ToArray();
            var sourceArr = source.ToArray();
            Array.Sort(cloned, sourceArr);
            return sourceArr;
        }
    }
