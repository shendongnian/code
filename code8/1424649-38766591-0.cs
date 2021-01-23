    private object GetValueByPropertyName<T>(T obj, string propertyName)
    {
        PropertyInfo propInfo = typeof(T).GetProperty(propertyName);
    
        return propInfo.GetValue(obj);
    }
