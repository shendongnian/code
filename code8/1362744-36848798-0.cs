    public class ClassA
    {
      public ClassB InstanceOfClassB { get; set; }
      
      public ClassA()
      {
        InstanceOfClassB = new ClassB();
      }
      //More code here
    }
    
    public class ClassB
    {
      //Code here
    }
