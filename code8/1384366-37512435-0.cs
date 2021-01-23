    private void AssignProperty(object obj, string propertyName, string propertyValue)
    {
        PropertyInfo property = obj.GetType().GetProperty(propertyName);
        property.SetValue(obj, Convert.ChangeType(propertyValue, property.PropertyType), null);
    }
