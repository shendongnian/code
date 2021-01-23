    using System.Reflection;
    ...
    private static void ApplyNullsForZeroes(Object value) {
      if (null == value)
        return; // Or throw exception 
      var props = value.GetType()
        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .Where(p => p.CanRead && p.CanWrite)
        .Where(p => p.PropertyType == typeof(Nullable<Double>));
      foreach (var p in props)
        if (Object.Equals(p.GetValue(value), 0.0))
          p.SetValue(value, null);
    }
