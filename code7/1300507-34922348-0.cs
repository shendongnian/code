    public class ImportParameter : System.Attribute
    {
      public Boolean Required {get; private set;}
    
      public ImportParameter(Boolean required)
      {
          this.Required = required;
      }
    }
