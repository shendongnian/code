        public static T PropertyOrDefault<T>(dynamic obj, string propertyName)
        {
            if (obj is ExpandoObject)
            {
                return ((ExpandoObject)obj).PropertyOrDefault<T>(propertyName);
            }
            Type objectType = obj.GetType();
            PropertyInfo p = objectType.GetProperty(propertyName);
            if (p != null)
            {
                object propertyValue = p.GetValue(obj);
                if (propertyValue is T)
                {
                    return (T)propertyValue;
                }
            }
            return default(T);
        }
