     public static T TrimSpaces<T>(this T obj)
        {
            if (obj == null)
            {
                return obj;
            }
            //Iterates all properties and trims the values if they are strings
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
            // This is to take care of Lists. This iterates through each value
            // in the list.
            // For example, Countries which is a List<Country>
            var baseTypeInfo = obj.GetType().BaseType;
            if (baseTypeInfo != null && baseTypeInfo.FullName.Contains("List"))
            {
                int listCount = (int)obj.GetType().GetProperty("Count").GetValue(obj, null);
                for (int innerIndex = 0; innerIndex < listCount; innerIndex++)
                {
                    object item = obj.GetType()
                        .GetMethod("get_Item", new Type[] { typeof(int) })
                        .Invoke(obj, new object[] { innerIndex });
                    item.TrimSpaces();
                }
            }
            // Now once we are in a complex type (for example Country) it then needs to
            // be trimmed recursively using the initial peice of code of this method
            // Hence if it is a complex type we are recursively calling TrimSpaces
            var customTypes =
                obj.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(
                        prop =>
                            !prop.GetType().IsPrimitive && prop.GetType().IsClass &&
                            !prop.PropertyType.FullName.StartsWith("System"));
            foreach (var customType in customTypes)
            {
                // If it's a collection, let the about piece of code take care
                // Only, normal types like, Code etc will be trimmed
                if (customType.GetIndexParameters().Length == 0)
                {
                    customType.GetValue(obj).TrimSpaces();
                }
            }
            return obj;
        }
