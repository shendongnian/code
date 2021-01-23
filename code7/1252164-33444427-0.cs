    private static Dictionary<PropertyInfoKey, PropertyInfo> propertyCache = 
      new Dictionary<PropertyInfoKey, PropertyInfo>()
    private class PropertyInfoKey : IEquatable 
    {
      public PropertyInfoKey(string fullName, string propertyName)
      {  
        FullName = fullName;
        PropertyName = propertyName
      }
      public string FullName { get; private set; }
      public string PropertyName { get; private set; }
      public bool Equals(PropertyInfoKey other)
      {
        if ( ..// do argument checking
        var result = FullName == other.FullName
          && PropertyName == other.PropertyName;
        return result;
      }
    }
    public static bool TryGetPropValue<T>(T src, 
      string propName, 
      out object value)
      where T : class
    {
      var key = new PropertyInfoKey(
        fullName: typeof(T).FullName,
        propertyName: propName
      );
      PropertyInfo propertyInfo;
      value = null;
      var result = propertyCache.TryGetValue(key, out propertyInfo);
      if (!result)
      {
        propertyInfo = typeof(T).GetProperty(propName);
        result = (propertyInfo != null);
        if (result)
        {
          propertyCache.Add(key, propertyInfo)
        }  
      }
      if (result)
      {
        value = propertyInfo.GetValue(src, null);
      }
      return result;
    }
