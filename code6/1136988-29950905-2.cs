    public class TestClass :IDisposable
    {
    
        public void Dispose()
        {
            if (!IsDisposed) //Check if _disposable is not disposed
                _disposable.Dispose();
        }
