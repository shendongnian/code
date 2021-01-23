    public ExampleClass : IDisposable
    {
        public ExampleClass(string connectionStringName, ILogger log)
        {
            //...
            Db = new Entities(connectionStringName);
            
            // let's pretend I have some code that can throw an exception here.
            throw new Exception("something went wrong AFTER constructing Db");
        }
        private bool _isDisposed;
        public void Dispose()
        {
            if (_isDisposed) return;
            Db.Dispose();
            _isDisposed= true;
        }
    }
