    public static class Utility
    {	
      public static void SetProperty(PropertyInfo property, object target, IEnumerable value)
      {
        var valueType = property.PropertyType.GetGenericArguments()[0];
        
        var genericConvertMethod = ConvertMethod.MakeGenericMethod(valueType);
        
        object correctlyTypedValue = genericConvertMethod.Invoke(null, new [] {value});
        
        property.SetValue(target, correctlyTypedValue);  
      }
      
      private static readonly MethodInfo ConvertMethod = typeof(Utility).GetMethod("Convert",BindingFlags.Static|BindingFlags.NonPublic);
    
      private static IEnumerable<T> Convert<T>(IEnumerable source)
      {
        // ToList is optional - depends on the behavior you want
        return source.OfType<T>().ToList();
      }
    }
