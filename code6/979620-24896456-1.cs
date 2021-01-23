    public static class MoreEnumerable
    {
        public static bool HasAtLeast<T>(this IEnumerable<T> source, int count)
        {
            if (source is ICollection<T>)
            {
                return ((ICollection<T>)source).Count > count;
            }
            else if (source is ICollection)
            {
                return ((ICollection)source).Count > count;
            }
            
            return source.Skip(count).Any();
        }
    }
