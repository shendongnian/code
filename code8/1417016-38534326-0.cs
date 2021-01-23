    public static class MyExtensions
    {
        public static IOrderedEnumerable<T> Sort(this IEnumerable<T> items) where T : IComparable
        {
            return items.OrderBy(i => i);
        }
    }
