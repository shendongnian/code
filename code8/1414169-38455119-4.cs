    public static class ObjectExtensions
    {
        public static int GetNumberOfProperties(this object value)
        {
            return value.GetType().GetProperties().Count();
        }
    }
