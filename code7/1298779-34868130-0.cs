    public static class EnumExt
    {
        public static T GetKey<T>(int value) where T : struct
        {
            T result;
            if (!Enum.TryParse(value.ToString(), out result))
                // no match found - throw an exception?
            return result;
        }
    }
