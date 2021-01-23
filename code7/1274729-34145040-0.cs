    public static class EnumerableExtensions
    {
        public delegate bool ParseDelegate<T>(string input, out T value) where T : struct;
        public static T?[] ToNullable<T>(this string[] values, ParseDelegate<T> parseMethod) where T : struct
        {
            IEnumerable<T?> cos = values.Select(s =>
            {
                T result;
                if (parseMethod(s, out result))
                {
                    return (T?)result;
                }
                return null;
            });
            return cos.ToArray();
        }
    }
