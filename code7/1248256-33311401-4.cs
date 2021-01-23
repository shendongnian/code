    public static class NullableEnum
    {
        public static bool TryParse<T>(string value, out T? result) where T :struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new Exception("This method is only for Enums");
            T tempResult = default(T);
            if (Enum.TryParse<T>(value, out tempResult))
            {
                result = tempResult;
                return true;
            }
            result = null;
            return false;
        }
    }
