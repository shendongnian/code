    public static class ObjectExtensions {
      public static List<KeyValuePair<string, object>> GetProperties(this object me) {
        List<KeyValuePair<string, object>> result = new List<KeyValuePair<string, object>>();
        foreach (var property in me.GetType().GetProperties()) {
          result.Add(new KeyValuePair<string, object>(property.Name, property.GetValue(me)));
        }
        return result;
      }
    }
