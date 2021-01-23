    public static bool Check(Object instance) {
      // Or false, or throw an exception
      if (Object.ReferenceEquals(null, instance))
        return true;
      //TODO: elaborate - do you need public as well as non public field? Static ones?
      var fields = instance.GetType().GetFields(
        BindingFlags.Instance |
        BindingFlags.Static |
        BindingFlags.Public |
        BindingFlags.NonPublic);
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
      return true;
    }
