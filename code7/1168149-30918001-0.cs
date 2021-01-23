    public class A
    {
      Func<B> _b;
      public A(Func<B> b) { _b = b; }
      public void M()
      {
        var b = _b();
        b.DoSomething();
      }
    }
