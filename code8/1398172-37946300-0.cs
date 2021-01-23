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
       System.ConsoleWriteLine(B.MyInstance.MyProperty.ToString()); // "10\n"
    }
