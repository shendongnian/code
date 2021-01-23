    public class SomeClass
    {
       public T GetInstance() where T : TestBase
       {
          var inst=new TestDerived();
          return inst;
       }
    }
