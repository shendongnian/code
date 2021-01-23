    public class AsyncSerial : SerialPort, IDisposable
    {
        // SomeClass implements IDisposable
        private SomeClass _disposableInstance;
        // ...
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(_disposableInstance != null)
                    _disposableInstance.Dispose();
            }
 
            // Call the base Dispose, to release resources on the base class.
            base.Dipose(disposing);
        }
    }
