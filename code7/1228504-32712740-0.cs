    public class Properties
        {
            public IDictionary<string, string> ExtendedProperties
            {
                get;
                set;
            }
    
          public Properties()
          {
             this.ExtendedProperties = new Dictionary<string, string>()
             {
                { "Name", String.Empty },
                { "Number", String.Empty },
                { "Age", String.Empty },
             };
    
          }
        }
