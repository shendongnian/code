      private static Dictionary<int, Type> types = new Dictionary<int, Type>() {
        {1, typeof(ClassA)},
        {2, typeof(ClassB)},
        {3, typeof(ClassC)},
        ... and so on
      };
    
      public static Type GetById(int id) {
        Type result = null;
    
        if (types.TryGetValue(id, out result))
          return result;
    
        return null; // or throw exception
      }
