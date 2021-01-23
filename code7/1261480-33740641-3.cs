    public static class Guard
    {
        public static void ForLessEqualZero(this int value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }
        public static void ForPrecedesDate(this DateTime value, DateTime dateToPrecede, string parameterName)
        {
            if (value >= dateToPrecede)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }
        public static void ForNullOrEmpty(this string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }
        public static void ForNull<T>(this T value, string parameterName)
        {
            ForValueType<T>(parameterName);
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
        private static void ForValueType<T>(string parameterName)
        {
            if (typeof(T).IsValueType)
            {
                throw new ArgumentException("parameter should be reference type, not value type", parameterName);
            }
        }
    }
