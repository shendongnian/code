    public static object GetNestedPropertyValue(object obj, string nestedDottedPropertyName)
    {
        foreach (String part in nestedDottedPropertyName.Split('.'))
        {
            if (obj == null)
                return null;
            PropertyInfo info = obj.GetType().GetProperty(part);
            if (info == null)
                return null;
            obj = info.GetValue(obj, null);
        }
        return obj;
    }
