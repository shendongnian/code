2 Fluent API
    public static class PrimitivePropertyConfigurationExtensions 
    { 
      public static PrimitivePropertyConfiguration AsDate(this PrimitivePropertyConfiguration property)
      {
        property.HasColumnType("date");
      }
    
      public static PrimitivePropertyConfiguration AsTimeOfDay(this PrimitivePropertyConfiguration property)
      {
        property.HasColumnType("time");
      }
    } 
