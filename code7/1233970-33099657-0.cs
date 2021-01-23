    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple, MaxItemsInObjectGraph = 2147483647)]
    [GlobalErrorBehaviorAttribute(typeof(GlobalErrorHandler))]
    public partial class YourService : IYourService
    {
        // Flag: Has Dispose already been called? 
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        // Public implementation of Dispose pattern callable by consumers. 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // Protected implementation of Dispose pattern. 
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here. 
                //
            }
            // Free any unmanaged objects here. 
            //
            disposed = true;
        }
        ~YourService()  // destructor
        {
          Dispose();
        }
