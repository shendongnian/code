    internal sealed class Library : IDisposable
    {
      IntPtr _libPtr; // Or better yet, can we use or derive from SafeHandle?
      public Library(string dllPath)
      {
         _libPtr = NativeMethods.LoadLibrary(dllPath);
         if(_libPtr == IntPtr.Zero)
         {
           GC.SuppressFinalize(this);
           throw new DllNotFoundException("Library Load Failed");
         }
      }
      private void Release()
      {
        if(_libPtr != IntPtr.Zero)
          NativeMethods.FreeLibrary(_libPtr);
        _libPtr = IntPtr.Zero; // avoid double free even if a caller double-disposes.
      }
      public void Dispose()
      {
        Release();
        GC.SuppressFinalize(this);
      }
      ~Library()
      {
        Release();
      }
      public IntPtr GetProcAddress(string functionName)
      {
        if(_libPtr == IntPtr.Zero)
          throw new ObjectDisposedException();
        IntPtr funcPtr = NativeMethods.GetProcAddress(_libPtr, functionName);
        if(_funcPtr == IntPtr.Zero)
          throw new Exception("Error binding function.");
        return _funcPtr;
      }
    }
