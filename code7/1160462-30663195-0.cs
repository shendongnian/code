      public interface IMyIntf {
        void SomeMethod();
      }
    
      public class MyClass: IMyIntf {
        ...
        // explicit interface implementation: works as "private"
        // unless cast to the interface
        void IMyIntf.SomeMethod() {
          ...
        }
      }
    
      ...
    
      MyClass inst = new MyClass();
    
      inst.SomeMethod(); // <- compile time error: SomeMethod() is not exposed
    
      // Only when cast the inst to the interface one can call the method:
      ((IMyIntf) inst).SomeMethod();
