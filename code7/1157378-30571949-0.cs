    public static class MyExtensions
    {
      public static T ConvertToT<T, P>(this P ob)
        where T : class
        where P : class
      {
        // ...
      }
    }
