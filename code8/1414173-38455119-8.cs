    public static class ObjectExtensions
    {
        public static int GetNumberOfProperties(this object value)
        {
            return value.GetType().GetProperties().Count();
        }
        public static int GetNumberOfProperties(this Type value)
        {
            return value.GetProperties().Count();
        }
    }
