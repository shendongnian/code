    public static class EnumSplitter
    {
        public static T[] Convert<T>(string delimitedValues) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException();
            }
            if (delimitedValues == string.Empty)
            {
                return new T[0];
            }
            string[] parts = delimitedValues.Split(',');
            T[] converted = new T[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                if (!Enum.TryParse(parts[i], out converted[i]))
                {
                    throw new FormatException(parts[i]);
                }
            }
            return converted;
        }
        public static TArray ConvertArray<TArray>(string delimitedValues) where TArray : IList
        {
            return MethodCache<TArray>.Convert(delimitedValues);
        }
        public static T?[] ConvertNullable<T>(string delimitedValues) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException();
            }
            if (delimitedValues == string.Empty)
            {
                return new T?[0];
            }
            string[] parts = delimitedValues.Split(',');
            T?[] converted = new T?[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == string.Empty)
                {
                    continue;
                }
                T value;
                if (!Enum.TryParse(parts[i], out value))
                {
                    throw new FormatException(parts[i]);
                }
                converted[i] = value;
            }
            return converted;
        }
        public static TArray ConvertNullableArray<TArray>(string delimitedValues) where TArray : IList
        {
            return MethodCache<TArray>.Convert(delimitedValues);
        }
        private static class MethodCache<TArray> where TArray : IList
        {
            public static readonly Func<string, TArray> Convert;
            static MethodCache()
            {
                if (!typeof(TArray).IsArray)
                {
                    throw new ArgumentException("TArray");
                }
                Type element = typeof(TArray).GetElementType();
                Type element2 = Nullable.GetUnderlyingType(element);
                if (element2 == null)
                {
                    Convert = (Func<string, TArray>)Delegate.CreateDelegate(typeof(Func<string, TArray>), typeof(EnumSplitter).GetMethod("Convert").MakeGenericMethod(element));
                }
                else
                {
                    Convert = (Func<string, TArray>)Delegate.CreateDelegate(typeof(Func<string, TArray>), typeof(EnumSplitter).GetMethod("ConvertNullable").MakeGenericMethod(element2));
                }
            }
        }
    }
