      using System.Reflection;
      ... 
      class JiraIDs {
        private static Dictionary<String, String> s_PropertiesMap = 
          new Dictionary<String, String>() {
          {"Customer ID", "customId"},
          ...
        };
    
        private PropertyInfo GetPropertyInfo(String name) {
          String propertyName;
          if (!s_PropertiesMap.TryGetValue(name, out propertyName))
            propertyName = name;
          return GetType().GetProperty(propertyName);
        } 
        ...
        public object this[String name] {
          get {
            return GetPropertyInfo(name).GetValue(this, new object[0]);
          }
          set {
            GetPropertyInfo(name).SetValue(this, value);
          }   
        }
      }
