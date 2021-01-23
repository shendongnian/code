     public class Properties
        {
            private Dictionary<string, string> extendedProperties = new Dictionary<string, string> ()
            {
                    { "Name", "" },
                    { "Number", "" },
                    { "Age", "" },
            };
    
            public IDictionary<string, string> ExtendedProperties 
            {
                get { return extendedProperties; }
            }
        }
