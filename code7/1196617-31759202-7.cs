    // You don't need generic, Object is quite enough 
    public static bool Check(Object instance) {
      // Or false, or throw an exception
      if (Object.ReferenceEquals(null, instance))
        return true;
    
      //TODO: elaborate - do you need public as well as non public properties? Static ones?
      var properties = instance.GetType().GetProperties(
        BindingFlags.Instance | 
        BindingFlags.Static | 
        BindingFlags.Public | 
        BindingFlags.NonPublic);
    
      foreach (var prop in properties) {
        if (!prop.CanRead) // <- exotic write-only properties
          continue;
        else if (prop.PropertyType.IsValueType) // value type can't be null
          continue;
    
        Object value = prop.GetValue(prop.GetGetMethod().IsStatic ? null : instance);
  
        if (Object.ReferenceEquals(null, value))
          return false;
        //TODO: if you don't need check STRING properties for being empty, comment out this fragment
        String str = value as String; 
        if (null != str)
          if (str.Equals(""))
            return false;
      }
    
      return true;
    }
