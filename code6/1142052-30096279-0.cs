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
                foreach (PropertyInfo property in property.PropertyType.GetProperties(flags))
                {
                    yield return property;
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
