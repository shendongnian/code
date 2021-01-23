    public class A
    {
      public void Method(params object[] args)
      {
    
      }
    }
    
    A a = new A();
    // You can give infinite arguments and they'll be received as indexes
    // of the "args" array
    a.Method(1, "hello world", true);
