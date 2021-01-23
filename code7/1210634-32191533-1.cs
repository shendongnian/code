    public static class ReflectionHelper
    {
        public static IEnumerable<PropertyInfo> GetTreeProperties<T>(T obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties()
               .Where(x => x.PropertyType.IsSubclassOf(typeof(T)) || x.GetValue(obj) as IEnumerable<T> != null);
            return properties;
        }
    }
