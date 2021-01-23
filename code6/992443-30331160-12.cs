    public struct AsyncFlowControl: IDisposable
    {
        private bool useEC;
        private ExecutionContext _ec;
    
        //..not relevent code here. 
    
    [SecurityCritical]
        internal void Setup()
        {
            useEC = true;
            Thread currentThread = Thread.CurrentThread;
            _ec = currentThread.GetMutableExecutionContext();
            _ec.isFlowSuppressed = true;
            _thread = currentThread;
        }
      }
