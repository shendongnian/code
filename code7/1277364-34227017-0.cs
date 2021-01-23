    public static class CppExtensions
    {
        public static IEnumerable<T> EqualRange<T>(this IEnumerable<T> source, T val, IComparer<T> comparer)
        {
            return source.SkipWhile(s => comparer.Compare(s, val) < 0).TakeWhile(s => comparer.Compare(s, val) == 0);
        }
    }
