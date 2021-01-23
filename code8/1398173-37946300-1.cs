    public class A
    {
       public int MyProperty { get; set; }
    }
    
    public static class B
    {
       static B()
       {
           MyInstance = new A();
           MyInstance.MyProperty = 10;
       }
       public static A MyInstance { get; set; }
    }
    
    public class C
    {
       // not sure what your intention is here
       public C()
       {
           System.Console.WriteLine(B.MyInstance.MyProperty.ToString()); // "10\n"
       }
    }
