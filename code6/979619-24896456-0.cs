    public static class MoreEnumerable
    {
        public static bool HasAtLeast<T>(this IEnumerable<T> source, int count)
        {
            if (source is ICollection<T>)
            {
                return ((ICollection<T>)source).Count > count;
            }
            
            int i = 0;
            foreach(T item in source)
            {
                i++;
                if (i > count)
                    return true;
            }
            
            return false;
        }
    }
