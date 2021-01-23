    public class Foo : IDisposable
    {
        // MemoryStream implements IDisposable
        private readonly Stream _stream = new MemoryStream();
    
        private bool _disposed;
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
    
            if (disposing)
            {
                _stream.Dispose();
            }
            
            _disposed = true;
        }
    }
