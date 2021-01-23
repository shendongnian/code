    public static class Extensions
    {
        public static IEnumerable<T> Match<T>(this IEnumerable<T> items, Func<T, bool> condition, Action<T> action)
        {
            foreach (T item in items)
            {
                if (condition(item))
                {
                    action(item)
                }
                else
                {
                    yield return item;
                }
            }
        }
    }
