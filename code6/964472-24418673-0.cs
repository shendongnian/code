    public static Class StaticHelpers
    {
        public static bool AnyEx<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null) return false;
            return enumerable.Any();
        }
    }
