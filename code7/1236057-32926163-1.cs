    public static class ListEx {
      public static T Push<T>(this List<T> list) where T: new() {
        // Create an instance of T.
        var instance = new T();
        // Add it to the list.
        list.Add(instance);
        // Return the new instance.
        return instance;
      }
    }
