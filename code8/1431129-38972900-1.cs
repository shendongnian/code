    class BaseClass
    {
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                //dispose my resources
                DisposeManagedOverride();
            }
            CloseUnmanagedOverride();
        }
        protected virtual void DisposeManagedOverride() {}
        protected virtual void CloseUnmanagedOverride() {}
    }
