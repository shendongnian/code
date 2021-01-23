    public static class ListEx {
      public static T Push<T>(this List<T> list) {
        // Create an instance of T.
        var instance = Activator.CreateInstance<T>();
        // Add it to the list.
        list.Add(instance);
        // Return the new instance.
        return instance;
      }
    }
