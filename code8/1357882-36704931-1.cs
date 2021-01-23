    //...
    foreach(var field in newFields)
    {
        // ...
        PropertyInfo propInfo = typeof(CustomObject).GetProperty(field.Key);
        var value = propInfo.GetValue(customObject, null);
        PropertyInfo propInfo = null;
        
        // handles TEnum
        if (propInfo.PropertyType.IsEnum)
        {
            propInfo.SetValue(customObject, Enum.ToObject(propInfo.PropertyType, field.Value), null);
        }
        // handles TEnum?
        else if (Nullable.GetUnderlyingType(propInfo.PropertyType)?.IsEnum == true)
        // if previous line dont compile, use the next 2
        //else if (Nullable.GetUnderlyingType(propInfo.PropertyType) != null &&
        //         Nullable.GetUnderlyingType(propInfo.PropertyType).IsEnum)
        {
            propInfo.SetValue(customObject, Enum.ToObject(Nullable.GetUnderlyingType(propInfo.PropertyType), field.Value), null);
        }
        else
        {
            propInfo.SetValue(customObject, field.Value, null);
        }
    }
