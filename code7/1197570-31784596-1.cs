    public static class ClassExtensionMethods
    {
        public static string GetName<T>(this T tempClass)
        {
            return typeof(T).Name;
        }
    }
