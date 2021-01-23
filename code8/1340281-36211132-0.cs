    public static class NullableExtensions
    {
        public static T? AsNullable<T>(this T value) where T : struct
        {
            // Allow runtime use.
            // Not useful for linq-to-nhibernate, could be:
            // throw NotSupportedException();
            return new Nullable<T>(value);
        }
    }
