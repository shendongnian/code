    class A
    {
      public string Date { get; set; }
      public string SerialNo { get; set; }
    }
    
    class B : A
    {
      public string Bill { get; set; }
      public string InstallationNo { get; set; }
    }
    
    public static IEnumerable<PropertyInfo> GetProperties(Type type)
    {
      if (type.BaseType == typeof(object)) return type.GetProperties().OrderBy(i => i.Name);
      
      return GetProperties(type.BaseType)
             .Concat
               (
                 type
                 .GetProperties
                   (BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                 .OrderBy(i => i.Name)
               );
    }
