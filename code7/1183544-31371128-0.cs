    public class MyObject
    {
       public SomeOtherObject dependentObject;
      [InjectionMethod]
      public void Initialize(SomeOtherObject dep) 
      {
        // assign the dependent object to a class-level variable
        dependentObject = dep;
      }
    }
