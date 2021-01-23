    class encryption : IDisposable
    {
    [....]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing){
            if (disposing)
            {
                if(provider != null) provider.Dispose();
            }
        }
    }
    
