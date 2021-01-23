     public static class NullableEnum
    {
        public static bool TryParse<T>(string value, out T? result) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("Invalid Enum");
            result = Enum.TryParse(value, out T tempResult) ? tempResult : default(T?);
                        
            return (result == null) ? false : true;
        }
    }
