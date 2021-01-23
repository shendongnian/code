    public static class ExtensionMethods
    {
        public static void YourMethod(this IList objectToPool)
        {
        }
        // or if you prefer this:
        public static void YourMethod<T>(this List<T> objectToPool)
        {
        }
    }
