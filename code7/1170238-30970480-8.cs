    public class SomeClass : IDisposable
    {
      private IntPtr _someHandle;
      public SomeClass(string someIdentifier)
      {
        _someHandle = GetHandle(someIdentifier);
      }
      public void Dispose()
      {
        ReleaseHandle(_someHandle);
        _someHandle = null; // so we know not to release twice.
      }
      ~SomeClass()
      {
        if(_someHandle != null)
          ReleaseHandle(_someHandle);
      }
    }
