    public class DisposableChild : DisposableParent, IDisposable
    {
        private bool _disposed = false;
        public new void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!_disposed)
                {
                    base.Dispose();
                    Console.WriteLine("The child was disposed.");
                    _disposed = true;
                }
            }
        }
    }
