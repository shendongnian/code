    // interface is public when its implementation is internal
    internal class Doer : ICanDoSomething {
      // To prevent creating Doer as Doer
      protected Doer() { // or private, internal, protected internal
        //Some staff if required
      }
       
      public void CanDoA() {... }
    
      public void CanDoB() {... }
    
      // Technically possible
      public void CanDoC() {... }
    }
    public static class DoerFactory {
      // ... create instead Doer as ICanDoSomething instance
      // (factory method)
      public static ICanDoSomething Create() {
        return new Doer();
      } 
    }
    
    ...
    
    ICanDoSomething test = DoerFactory.Create();
    
    test.CanDoA(); // OK
    
    test.CanDoC(); // Compile time error
    
    (test as Doer).CanDoC(); // Compile time error when called in an assembly other than Doer
