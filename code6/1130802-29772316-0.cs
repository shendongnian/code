    var persistedDescriptor = ...;
    var currentDescriptor = Describe(typeof(Foo));
    bool isValid = persistedDescriptor.IsValidForSerialization(currentDescriptor);
    [Serializable]
    [DataContract]
    public class TypeDescriptor
    {
      [DataMember]
      public string TypeName { get; set; }
      [DataMember]
      public IList<FieldDescriptor> Fields { get; set; }
      public TypeDescriptor()
      {
        Fields = new List<FieldDescriptor>();
      }
      public bool IsValidForSerialization(TypeDescriptor currentType)
      {
        if (!string.Equals(TypeName, currentType.TypeName, StringComparison.Ordinal))
        {
          return false;
        }
        foreach(var field in Fields)
        {
          var mirrorField = currentType.Fields.FirstOrDefault(f => string.Equals(f.FieldName, field.FieldName, StringComparison.Ordinal));
          if (mirrorField == null)
          {
            return false;
          }
          if (!field.Type.IsValidForSerialization(mirrorField.Type))
          {
            return false;
          }
        }
        return true;
      }
    }
    [Serializable]
    [DataContract]
    public class FieldDescriptor
    {
      [DataMember]
      public TypeDescriptor Type { get; set; }
      [DataMember]
      public string FieldName { get; set; }
    }
    private static TypeDescriptor Describe(Type type, IDictionary<Type, TypeDescriptor> knownTypes)
    {
      if (knownTypes.ContainsKey(type))
      {
        return knownTypes[type];
      }
      var descriptor = new TypeDescriptor { TypeName = type.FullName, Fields = new List<FieldDescriptor>() };
      knownTypes.Add(type, descriptor);
      if (!type.IsPrimitive && type != typeof(string))
      {
        foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).OrderBy(f => f.Name))
        {
          var attributes = field.GetCustomAttributes(typeof(NonSerializedAttribute), false);
          if (attributes != null && attributes.Length > 0)
          {
            continue;
          }
          descriptor.Fields.Add(new FieldDescriptor { FieldName = field.Name, Type = Describe(field.FieldType, knownTypes) });
        }
      }
      return descriptor;
    }
    public static TypeDescriptor Describe(Type type)
    {
      return Describe(type, new Dictionary<Type, TypeDescriptor>());
    }    
    
