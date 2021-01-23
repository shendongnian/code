    public sealed class ExceptionGuard<T>:IDisposable where T:IDisposable
    {
        private readonly T instance;
        public bool ExceptionOccurred { get; private set; }
        
        public ExceptionGuard(T instance) { this.instance = instance; }
     
        public void Use(Action<T> useInstance)
        {
            try
            {
                useInstance(instance);
            }
            catch(Exception ex)
            {
                this.ExceptionOccurred = true;
                // Hopefully do something with your exception
            }        
        }
    
        public void Dispose()
        {
            Dispose(true);
        }
    
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.instance.Dispose();
            }
        }
    }
