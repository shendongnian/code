    class SubSystemGraph: ISubSystem, IDisposable
    {
      readonly Owned<SubSystem> _root;
      public SubSystemGraph(Owned<SubSystem> root)
      {
        _root = root;
      }
      public void Dispose()
      {
        _root.Dispose();
      }
      // Methods of ISubSystem delegate to _root.Value
      public void Foo()
      {
        _root.Value.Foo();
      }
    }
