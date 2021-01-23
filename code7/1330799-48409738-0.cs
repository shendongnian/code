    public static class ObjectExtensions
    {
        public static void SetValue<TValue>(this object @object, string propertyName, TValue value)
        {
            var property = @object.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            if (property?.CanWrite == true)
                property.SetValue(@object, value, null);
        }
    }
