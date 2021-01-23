    public static T TrimSpaces<T>(this T obj)
        {
            if (obj == null)
            {
                return obj;
            }
            var properties = obj.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(prop => prop.PropertyType == typeof(string))
                .Where(prop => prop.CanWrite && prop.CanRead);
            foreach (var property in properties)
            {
                var value = (string)property.GetValue(obj, null);
                if (value.HasValue())
                {
                    var newValue = (object)value.Trim();
                    property.SetValue(obj, newValue, null);
                }
            }
            var customTypes =
                obj.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(
                        prop =>
                            !prop.GetType().IsPrimitive && prop.GetType().IsClass &&
                            !prop.PropertyType.FullName.StartsWith("System"));
            foreach (var customType in customTypes)
            {
                if (customType.Name.Contains("Item"))
                {
                    continue;
                }
                customType.GetValue(obj).TrimSpaces();
            }
            return obj;
        }
