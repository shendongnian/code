    using System.Reflection;  // reflection namespace
    
    // get all public static properties of MyClass type
    PropertyInfo[] propertyInfos;
    propertyInfos = typeof(MyClass).GetProperties(BindingFlags.Public |
                                                  BindingFlags.Static);
    // sort properties by name
    Array.Sort(propertyInfos,
            delegate(PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
            { return propertyInfo1.Name.CompareTo(propertyInfo2.Name); });
    
    // write property names
    foreach (PropertyInfo propertyInfo in propertyInfos)
    {
      Console.WriteLine(propertyInfo.Name);
    }
