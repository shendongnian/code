    // You don't need generic, Object is quite enough 
    public static bool Check(Object instance) {
      // Or false, or throw an exception
      if (Object.ReferenceEquals(null, instance))
        return true;
      //TODO: elaborate - do you need public as well as non public field/properties? Static ones? 
      BindingFlags binding =
        BindingFlags.Instance |
        BindingFlags.Static |
        BindingFlags.Public |
        BindingFlags.NonPublic;
      // Fields are easier to check, let them be first
      var fields = instance.GetType().GetFields(binding);
      foreach (var field in fields) {
        if (field.FieldType.IsValueType) // value type can't be null
          continue;
        Object value = field.GetValue(field.IsStatic ? null : instance);
        if (Object.ReferenceEquals(null, value))
          return false;
        //TODO: if you don't need check STRING fields for being empty, comment out this fragment
        String str = value as String;
        if (null != str)
          if (str.Equals(""))
            return false;
      }
      // No null fields are found, let's see the properties
      var properties = instance.GetType().GetProperties(binding);
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
