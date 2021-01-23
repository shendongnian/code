    public static class EnumExtensions
    {
       public static string EnumType(this Enum value)  
       {  
           FieldInfo field = value.GetType().GetField(value.ToString());  
      
           EnumTypeAttribute attribute  
                   = Attribute.GetCustomAttribute(field, typeof(EnumTypeAttribute ))  
                       as EnumTypeAttribute;  
      
           return attribute == null ? value.ToString() : attribute.EnumType ;  
       }  
    }  
