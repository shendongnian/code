       class JiraIDs {
         private static Dictionary<String, String> s_PropertiesMap; // no explict fill
    
         static JiraIDs() {
           s_PropertiesMap = typeof(JiraIDs).GetProperties()
             .SelectMany(property => 
               Attribute.GetCustomAttributes(property)
                 .OfType<MyPropertyAliasAttribute>()
                 .Select(attribute => new {
                    Alias = attribute.Alias,
                    Property = property.Name 
                  }))
             .ToDictionary(record => record.Alias, 
                           record => record.Property);
         }
         ...
         [MyPropertyAlias("Customer ID")]
         public decimal customId { get; set; }
         ...
