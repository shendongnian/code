    private static class RecentHolder<T> {
        public static IList<T> Value { get; set; }
    }
    public static Blah<T>(this IList<T> ra) {
        RecentHolder<T>.Value = ra;
    }
