    public static class ObjectExtensions
    {
        public static Dictionary<string,object> GetProperties(this object obj, string properties)
        {
            var propertyNames = properties.Split(',');
            var result = new Dictionary<string, object>();
            var type = obj.GetType();
            foreach (var property in propertyNames)
            {
                var prop = type.GetProperty(property);
                var value = prop.GetValue(obj);
                result.Add(property, value);
            }
            return result;
        }
    }
