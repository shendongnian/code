    public static class MyExtension
    {
        public static void RemoveAllWithPropertyValue<T>(this List<T> list, string propertyName, object value)
        {
            var property = typeof(T).GetProperty(propertyName);
            list.RemoveAll(item => property.GetValue(item, null).Equals(value));
        }
    }
