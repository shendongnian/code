    public class SomeHybridClass : IDisposable
    {
      private IntPtr _someHandle;
      private SomeClass _someObj;
      public SomeHybridClass(string someIdentifier)
      {
        _someHandle = GetHandle(someIdentifier);
        _someObj = new SomeClass(someIdentifier);
      }
      protected virtual void Dispose(bool disposing)
      {
        // if this in turn was derived, we'd call
        // base.Dispose(disposing) here too.
        if(disposing)
        {
          _someObj.Dispose();
        }
        ReleaseHandle(_someHandle);
      }
      public void Dispose()
      {
        Dispose(true);
        GC.SuppressFinalize(this);
      }
      ~SomeHybridClass()
      {
        Dispose(false);
      }
    }
