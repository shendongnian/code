    public static Child ConvertToChildObject(this PropertyInfo propertyInfo, object parent)
    {
        var source = propertyInfo.GetValue(parent, null);
        var destination = Activator.CreateInstance(propertyInfo.PropertyType);
        foreach (PropertyInfo prop in destination.GetType().GetProperties().ToList())
        {
           var value = source.GetType().GetProperty(prop.Name).GetValue(source, null);
           prop.SetValue(destination, value, null);
        }
     return (Child) destination; 
    }
