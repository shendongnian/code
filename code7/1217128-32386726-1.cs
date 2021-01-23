    abstract class A {
      public Image Symbol { get; protected set; }
    }
    class B:A {
      private static Image SymbolInstance { get; private set; }
      static B() {
        // SymbolInstance = ...
      }
      public B() {
        Symbol = SymbolInstance;
      }
    }
