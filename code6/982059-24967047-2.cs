    public static string GetNestedProperty(object value, string propertyName)
    {
        var type = value.GetType();
        var property = type.GetProperty("inobjects");
        value = property.GetValue(value, null);
        type = property.PropertyType;
    
        property = type.GetProperty(propertyName);
    
        if (property == null)
        {
            return null;
        }
    
        value = property.GetValue(value, null);
        return (string) value;
    }
