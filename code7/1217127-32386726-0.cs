    abstract class A {
      public static Image Symbol { get; protected set; }
    }
    class B:A {
      static B() {
        // Symbol = ...
      }
    }
