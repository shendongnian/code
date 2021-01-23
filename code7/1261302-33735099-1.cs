    public static class EnumerableExtensions
    {
        private static readonly MethodInfo CastMethod;
        static EnumerableExtensions()
        {
            CastMethod = typeof(Enumerable).GetMethod("Cast", BindingFlags.Public | BindingFlags.Static);
        }
        public static object Cast(this IEnumerable input, Type targetType)
        {
            return CastMethod.MakeGenericMethod(targetType).Invoke(null, new object[] { input });
        }
    }
