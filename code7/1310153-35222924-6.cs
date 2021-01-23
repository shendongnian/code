    public static List<PropertyDescription> ReadObject(Type type)
    {
        var propertyDescriptions = new List<PropertyDescription>();
        foreach (var propertyInfo in type.GetProperties())
        {
            var propertyDescription = new PropertyDescription
            {
                PropertyName = propertyInfo.Name,
                Type = propertyInfo.PropertyType.Name,
                IsPrimitive = propertyInfo.PropertyType.IsPrimitive
            };
            if (!propertyDescription.IsPrimitive
                // String is not a primitive type
                && propertyInfo.PropertyType != typeof (string))
            {
                propertyDescription.IsPrimitive = true;
                propertyDescription.Properties = ReadObject(propertyInfo.PropertyType);
            }
            propertyDescriptions.Add(propertyDescription);
        }
        return propertyDescriptions;
    }
