    public static class IReadOnlyListExtensions
    {
        public static IEnumerable<T> Skip<T>(this IReadOnlyList<T> collection, int count)
        {
            if (collection == null)
                return null;
            return ICollectionExtensions.YieldSkip(collection, count);
        }
        private static IEnumerable<T> YieldSkip<T>(IReadOnlyList<T> collection, int count)
        {
            for (int index = count; index < collection.Count; index++)
            {
                yield return collection[index];
            }
        }
    }
