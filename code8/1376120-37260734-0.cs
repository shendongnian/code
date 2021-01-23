    public class DisposeMe : IDisposable
    {
        public bool Disposed {get;set;}
        public void Dispose()
        {
            Disposed = true;
        }
    }
