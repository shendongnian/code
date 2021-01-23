    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                var itemAsEnumerable = Enumerable.Repeat(item, 1);
                var subSet = items.Except(itemAsEnumerable);
                if (!subSet.Any())
                {
                    yield return itemAsEnumerable;
                }
                else
                {
                    foreach (var sub in items.Except(itemAsEnumerable).GetPermutations())
                    {
                        yield return itemAsEnumerable.Union(sub);
                    }
                }
            }
        }
