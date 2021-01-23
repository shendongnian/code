    public void Set(object obj, string property, object value)
    {
        var propertyInfo = obj.GetType().GetProperty(property);
        propertyInfo?.SetValue(obj, value);
    }
