      public class MyBase {
        public virtual String A {
          get {
            return "getBaseA";
          }
          set {
            throw new InvalidOperationException("setBaseA");
          }
        }
      }
