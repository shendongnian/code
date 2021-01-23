    public class SomeClass : IDisposable
    {
        private bool disposed;
    
        //disposing is true if you're disposing managed resources
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //Dispose managed resources
                }
                //Dispose unmanaged resources
                disposed = true;
            }
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        ~SomeClass()
        {
            Dispose(false);
        }
    }
