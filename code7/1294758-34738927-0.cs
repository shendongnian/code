    public class A
    {
      ILifetimeScope  _scope;
    
      public A(ILifetimeScope scope) { _scope = scope; }
    
      public void M()
      {
          var b = _scope.Resolve<B>();
          b.DoSomething();
      }
    }`
