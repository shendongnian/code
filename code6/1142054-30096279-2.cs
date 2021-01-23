    List<PropertyInfo> properties = new List<PropertyInfo>();
    foreach (object obj in myList)
    {
        properties.AddRange(GetDeepProperties(obj, ...));
    }
    PropertyInfo[] array = properties.ToArray();
...
    IEnumerable<PropertyInfo> GetDeepProperties(object obj, BindingFlags flags)
    {
        // Get properties of the current object
        foreach (PropertyInfo property in obj.GetType().GetProperties(flags))
        {
            yield return property;
            
            object propertyValue = property.GetValue(obj, null);
            if (propertyValue == null)
            {
                // Property is null, but can still get properties of the PropertyType
                foreach (PropertyInfo subProperty in property.PropertyType.GetProperties(flags))
                {
                    yield return subProperty;
                }
            }
            else
            {
                // Get properties of the value assiged to the property
                foreach (PropertyInfo subProperty = GetDeepProperties(propertyValue))
                {
                    yield return subProperty;
                }
            }
        }
    }
