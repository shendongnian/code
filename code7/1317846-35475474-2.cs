    public class Wrapper
    {
      private object _wrapped;
      public Wrapper(classA obj)
      {
        _wrapped = obj;
      }
      public Wrapper(classB obj)
      {
        _wrapped = obj;
      }
      public int WrappedProperty
      { 
        get
        {
          var instA = _wrapped as classA;
          if (instA != null)
            return instA.SomeProperty1;
          var instB = _wrapped as classB;
          if (instB != null)
            return instB.SomeProperty2;
        }
      }
      private MyClass myclass;
      private EventHandler clicked;
      public event EventHandler Clicked { ... }
      private bool enabled;
      public bool Enabled { ... }
      private void HandleClicked(object sender, EventArgs e) { ... }
    }
