    public class Disposable : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            Console.WriteLine("I am disposed");
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }
    
        ~Disposable()
        {
            Dispose(false);
        }
    }
