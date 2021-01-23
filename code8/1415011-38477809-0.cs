    public static class AtLeastExtension
    {
        public static bool AtLeast<T>(this IEnumerable<T> enumerable, T e, int Max)
        {
            int cnt = 0;
            foreach (var item in enumerable)
                if (item.Equals(e))
                    if (++cnt >= Max) return true;
            return false;
        }
    }
