    using System;
    using System.Collections.Generic;
    
    namespace My.Namespace
    {
        public class Properties
        {
            public IDictionary<string, string> ExtendedProperties { get; set; }
    
            public Properties()
            {
                ExtendedProperties = new Dictionary<string, string>
                {
                    ["Name"] = String.Empty,
                    ["Number"] = String.Empty,
                    ["Age"] = String.Empty
                };
            }
        }
    }
