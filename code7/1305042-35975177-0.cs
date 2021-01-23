    public static class ObjectExtensions
    {
        public static T As<T>(this object obj) where T : class
        {
            return obj as T;
        }
    }
