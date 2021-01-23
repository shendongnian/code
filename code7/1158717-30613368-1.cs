    public interface IInterface1
    {
        void Method1();
    }
    
    public interface IInterface2
    {
        int Method3();
    }
    public class MyType2 : IInterface1, IInterface2
    {
      public void Method1()
      {
        ...
      }
      private void ADifferentMethod()
      {
        ...
      }
      public int Method3()
      {
        ...
      }
    }
