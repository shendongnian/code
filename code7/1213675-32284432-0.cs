    public static PropertyInfo GetPropertyByPath<T>(string objectPath)
    {
    var firstType = typeof(T);
    BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
    string[] objectPath = "object2.object3.object4".Split('.');
    
    // #1 property in the object path should be obtained from T
    PropertyInfo currentProperty = typeof(T).GetProperty(objectPath[0], bindingFlags);
    
    for(int propertyIndex = 1; propertyIndex < objectPath.Length; propertyIndex++)
    {
         // While all other association properties should be obtained
         // accessing PropertyInfo.PropertyType
         currentProperty = currentProperty.PropertyType
                          .GetProperty(objectPath[propertyIndex], bindingFlags);
         if(currentProperty == null)
              throw new ArgumentException("Some property in the object path doesn't exist", "objectPath");
    }
}
}
