    public class Test
    {
      public void CallBMethod()
      {
         //option 1
         A option1 = new B().getObject<A1>();
         //option 2
         A option2 = new B().getObject<A1Factory>();
        //Or skip the B.getObject method and access factory directly:
        A a1 = new A1Factory().Build();
        A a2 = new A2Factory().Build();
      }
    }
