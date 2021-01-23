    using System.Reflection;
    /// <summary>Finds properties that implement a type</summary>
    /// <param name="parent">The parent type</param>
    /// <param name="type">The filter type</param>
    /// <returns>Enumerable of PropertyInfo</returns>
    IEnumerable<PropertyInfo> Properties(Type parent, Type type)
    {
        var typeinfo = type.GetTypeInfo();
        var properties = parent.GetRuntimeProperties();
        foreach (PropertyInfo property in properties)
        {
            var propertytypeinfo = property.PropertyType.GetTypeInfo();
            if (typeinfo.IsAssignableFrom(propertytypeinfo))
                yield return property;
        }
    }
