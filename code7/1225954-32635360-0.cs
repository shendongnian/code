    // Definition of interface or sometimes referred to as "Contract"
    // Implementing classes must define these methods and properties
    public interface IMyInterface
    {
      void MyMethod();
      int MyProperty { get; }
    }
    // Implementation or sometimes referred to as "Concrete type"
    public class MyClass : IMyInterface
    {
      public void MyMethod();
      public int MyProperty { get; set; }
    }
    // Compile time type checking:
    public void MyMethod<T>(T value)
      where T : IMyInterface
    { }
    // Runtime checking
    public void MyMethod(object someobject)
    {
      var myinterface = someobject as IMyInterface;
      if (myinterface != null)
      {
        //someobject implements IMyInterface so I can do things with it
        someobject.MyMethod();
      }
    }
