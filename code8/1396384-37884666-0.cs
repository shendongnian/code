    public static class IComparableExtensions
    {
        public static T Min<T>(this T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) < 0 ? a : b;
        }
        public static T Max<T>(this T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
        public static T Clip<T>(this T a, T Min, T Max) where T : IComparable<T>
        {
            return a.Max(Min).Min(Max);
        }
    }
