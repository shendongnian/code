    public static class EnumExtension
    {
        public static int GetValue<T>(this T enumValue) where T:struct 
        {
           return (int)enumValue;
        }
    }
