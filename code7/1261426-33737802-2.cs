      public class MyClass {
        ...
        // Doesn't compile:
        // Either "first" or "second" should be of MyClass type
        public static Dictionary<string, int> operator / 
          (Dictionary<string, int> first, Dictionary<string, int> second) {...}
        ...
      }
