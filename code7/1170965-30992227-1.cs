    public sealed class MyClass : IDisposable
    {
      private readonly Library _lib;
      private readonly IntPtr _funcPtr;
      public MyClass(string dllPath)
      {
        _lib = new Library(dllPath); // If this fails, we throw here, and we don't need clean-up.
        try
        { 
          _funcPtr = _libPtr.GetProcAddress("MyFunction");
        }
        catch
        {
          // To be here, _lib must be valid, but we've failed over-all.
          _lib.Dispose();
          throw;
        }
      }
      public void Dispose()
      {
        _lib.Dispose();
      }
      // No finaliser needed, because no unmanaged resources needing finalisation are directly held.
    }
