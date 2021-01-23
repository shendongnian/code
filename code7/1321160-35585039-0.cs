    public static bool Check(Type type)
    {
      var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
      return props.Any(p => p.GetCustomAttribute(typeof(ObsoleteAttribute), false) != null);
    }
