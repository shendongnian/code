     public class DateTimeConverter : JavaScriptConverter
        {
          public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
          {
            throw new NotImplementedException();
          }
        
    
      public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
      {
        return new Dictionary<string, object> { { "", ((DateTime)obj).ToString("dd/MM/yyyy") } };
      }
    
    
      public override IEnumerable<Type> SupportedTypes { get { return [] { typeof(DateTime) }; } }
    
    
    }
