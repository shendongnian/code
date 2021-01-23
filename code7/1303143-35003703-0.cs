    public static class ValidationExtensions
    {
        public static bool IsValid(this object obj, Type type)
        {
            // Run your logic here.
            return true; // return Answer();
        }
        public static bool IsValid<T>(this object obj)
        {
            // Run your logic here.
            var type = typeof(T);
            return true;  // return Answer();
        }
    }
