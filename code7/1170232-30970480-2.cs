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
        GC.SuppressFinalize(this);
      }
      ~SomeClass()
      {
        ReleaseHandle(_someHandle);
      }
    }
