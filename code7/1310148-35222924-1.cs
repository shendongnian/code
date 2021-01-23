    public static List<PropertyDescription> ReadObject(object value)
    {
        var propertyDescriptions = new List<PropertyDescription>();
        foreach (var propertyInfo in value.GetType().GetProperties())
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
                propertyDescription.Properties = ReadObject(propertyInfo.GetValue(value));
            }
            else
            {
                propertyDescription.Value = propertyInfo.GetValue(value);
            }
            propertyDescriptions.Add(propertyDescription);
        }
        return propertyDescriptions;
    }
