    public object GetObjectToSerialize(object value, Type targetType) 
    {
        var type = value.GetType();
        PropertyInfo[] setToNullProperties;
        if (!_typeToPropertyMap.TryGetValue(type, out setToNullProperties)) 
        {
            PropertyInfo[] allProperties = type.GetProperties();
            var setToNullProperties2 = new List<PropertyInfo>(allProperties);
            foreach (PropertyInfo property in allProperties) 
            {
                bool isPasswordProperty = property.PropertyType == typeof(string) && property.Name.Contains("Password");
                bool isEncrypted = property.GetCustomAttributes(typeof(EncryptedConfigurationItemAttribute), false).Any();
                if (isPasswordProperty && !isEncrypted) 
                {
                    throw new InvalidOperationException();
                }
                if (isPasswordProperty || isEncrypted) 
                {
                    setToNullProperties2.Add(property);
                }
            }
            _typeToPropertyMap[type] = setToNullProperties = setToNullProperties2.ToArray();
        }
        foreach (var property in setToNullProperties) 
        {
            property.SetValue(value, null, null);
        }
        return value;
    }
