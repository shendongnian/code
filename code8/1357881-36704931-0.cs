    //...
    foreach(var field in newFields)
    {
        // ...
        PropertyInfo propInfo = typeof(CustomObject).GetProperty(field.Key);
        var value = propInfo.GetValue(customObject, null);
        if (propInfo.PropertyType.IsEnum)
        {
            propInfo.SetValue(customObject, Enum.ToObject(propInfo.PropertyType, field.Value), null);
        }
        else
        {
            propInfo.SetValue(customObject, field.Value, null);
        }
    }
