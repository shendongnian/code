    public class MyDerivedA: MyBase {
      public override String A {
        get {
          return "s";
        }
        set { // set is overridden, now set does nothing
        }
      }
    }
    
    public class MyDerivedB: MyBase {
      public override String A {
        get {
          return "s";
        }
        // set is not overridden, same as in the base class
      }
    }
