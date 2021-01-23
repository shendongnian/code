    public class Class1
    {
      public Class1 Instance {get; set;};
    }
    public class Class2
    {
         public void Test()
         {
             Class1 class1 = new Class1();
             var nestedInstance = class1.Instance;
         }
    }
