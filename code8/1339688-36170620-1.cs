    public static class Extensions
    {
        public static bool In<T>(this T item, params T[] items)
        {
             return items.Contains(item);
        }
    }
