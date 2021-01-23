    public class DBTransaction : IDataTransaction
    {
        ....
        ~DBTransaction()  // <- ONLY NEEDED IF YOU HAVE UN-MANAGED RESOURCES
        {
            Dispose(false);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if(_disposed) return;            
            try
            {
                // DISPOSE OF UN-MANAGED RESOURCES HERE
                if(disposing)
                {
                    //  Dispose objects here
                    _dbcontextTrans.Dispose();
                }
            }
            finally
            {
                _disposed = true;
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ...
    }
