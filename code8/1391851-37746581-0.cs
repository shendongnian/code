      using System.Reflection;
      ... 
      class JiraIDs {
        private static Dictionary<String, String> s_PropertiesMap = 
          new Dictionary<String, String>() {
          {"Customer ID", "customId"},
          ...
        };
    
        ...
        public object this[String name] {
          get {
            String propertyName;
    
            if (!s_PropertiesMap.TryGetValue(name, out propertyName))
              propertyName = name; 
    
            return GetType().GetProperty(propertyName).GetValue(this, new object[0]);
          }
          set {
            String propertyName;
    
            if (!s_PropertiesMap.TryGetValue(name, out propertyName))
              propertyName = name;  
            GetType().GetProperty(propertyName).SetValue(this, value);
          }   
        }
      }
