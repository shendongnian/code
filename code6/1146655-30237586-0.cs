    public static class EnumExtension
        {
            public static IEnumerable<T> GetValues<T>(this T e)
            {
                return Enum.GetValues(e.GetType()).Cast<T>();
            }
    }
