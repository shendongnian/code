    // ExampleClass is similar to WebResponse
    public class ExampleClass: IDisposable
    {
        private IDisposable somethingDisposable;
        private bool disposed = false;
        public ExampleClass() 
        {
            somethingDisposable = new ...
            ...
        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called. 
            if(!this.disposed)
            {
                if(disposing)
                {
                    // Your stream is disposed similar to
                    // what happens here:
                    // IDisposable objects dispose all managed/unmanaged 
                    // resources that they have in their Dispose function.
 
                    somethingDisposable.Dispose();
                }
                disposed = true;
            }
        }
        // This is similar to WebResponse.GetResponseStream
        public IDisposable GetSomethingDisposable() 
        {
            return somethingDisposable;
        }
    }
    public static void Main()
    {
        IDisposable d;
        using(var e = new ExampleClass()) {
            d = e.GetSomethingDisposable();
        }
        // here both e and d are disposed.
    }
