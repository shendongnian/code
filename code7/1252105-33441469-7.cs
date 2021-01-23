    public void Set(object obj, string property, object value)
    {
        //use reflection to get the PropertyInfo of the property you want to set
        //if the property is not found, GetProperty() returns null
        var propertyInfo = obj.GetType().GetProperty(property);
        //use the C# 6 ?. operator to only execute SetValue() if propertyInfo is not null
        propertyInfo?.SetValue(obj, value);
    }
