    public class SubUnmanaged : Base
    {
        IntPtr someNativeHandle;
        IDisposable someManagedResource;
        public override sealed void Dispose()
        {   
            base.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~SubUnmanaged();
        {
            base.Dispose();
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (someNativeHandle != IntPtr.Zero)
                Free(someNativeHandle);
            if (disposing)
               someManagedResource.Dispose();
        }
    }
