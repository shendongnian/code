      public class MyClass {
        ...
        // non static method
        private void SomeCall() { ... }
        private Dictionary<string, System.Action> explosions;
    
        public MyClass() {
          explosions = new Dictionary<string, System.Action>() {
            {"huge", SomeCall},
            {"huger", SomeCall},
          };
        }
        ...
      }
