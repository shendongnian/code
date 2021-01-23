    public sealed class SomeHybridClass : IDisposable
    {
      private IntPtr _someHandle;
      private SomeClass _someObj;
      public SomeHybridClass(string someIdentifier)
      {
        _someHandle = GetHandle(someIdentifier);
        _someObj = new SomeClass(someIdentifier);
      }
      public void Dispose()
      {
        ReleaseHandle(_someHandle);
        GC.SuppressFinalize(this);
        _someObj.Dispose();
      }
      ~SomeHybridClass()
      {
        ReleaseHandle(_someHandle);
      }
    }
