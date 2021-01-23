      // Helper class for fetching and caching FieldInfo values
      class FieldLookup {
        string sm_name;
        Dictionary<Type, FieldInfo> sm_cache;
        public FieldLookup(string name) {
          sm_name = name;
          sm_cache = new Dictionary<Type, FieldInfo>();
        }
        public FieldInfo Get(Type t) {
          try {
            return sm_cache[t];
          } catch (KeyNotFoundException) {
            var field = sm_cache[t] = t.GetField(
              sm_name,
              System.Reflection.BindingFlags.NonPublic |
              System.Reflection.BindingFlags.GetField |
              System.Reflection.BindingFlags.Instance);
            return field;
          }
        }
      }
    
      static FieldLookup sm_items = new FieldLookup("_items");
      public static T[] GetBackingArray<T>(this List<T> list) {
        return (T[])sm_items.Get(typeof(List<T>)).GetValue(list);
      }
