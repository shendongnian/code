      public class MyDerivedA: MyBase {
        public override String A {
          get {
            return "s";
          }
          set { // set is overriden, now set does nothing
          }
        }
      }
    
      public class MyDerivedB: MyBase {
        public override String A {
          get {
            return "s";
          }
          // set is not overriden, same as in the base class
        }
      }
