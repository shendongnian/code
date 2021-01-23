    public static Child ConvertToChiildObject(this PropertyInfo propertyInfo, object parent)
    {
        var source = propertyInfo.GetValue(parent, null);
        var destination = Activator.CreateInstance(propertyInfo.PropertyType)
        foreach(PropertyInfo prop in destination.GetProperties().ToList()){
           var value = source.GetProperty(prop.Name).GetValue(source, null);
           prop.SetValue(destination, value, null);
        }
     return (Child)destination; 
    }
