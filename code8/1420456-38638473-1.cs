    private void CopyPropertyValue(
        object source,
        string sourcePropertyName,
        object target,
        string targetPropertyName)
    {
        PropertyInfo sourceProperty = source.GetType().GetProperty(sourcePropertyName);
        PropertyInfo targetProperty = target.GetType().GetProperty(targetPropertyName);
        object value = sourceProperty.GetValue(source);
        if (value == null && 
            targetProperty.PropertyType.IsValueType &&
            Nullable.GetUnderlyingType(targetProperty.PropertyType) != null)
        {
            // Okay, trying to copy a null value into a non-nullable type.
            // Do whatever you want here
        }
        else
        {
            targetProperty.SetValue(target, value);
        }
    }
