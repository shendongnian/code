    public class IncludeScope : IDisposable
    {
        private const string CallContextKey = "IncludeScopKey";
     
        private object oldValue;
     
        public IncludeScope(IDictionary<string,int> values)
        {
            this.oldValue = CallContext.GetData(CallContextKey);
            this.Includes = new Dictionary<string,int>(values);
            CallContext.SetData(CallContextKey, this);
        }
     
        public Dictionary<string,int> Includes { get; private set; }
     
        public static IncludeScope Current {
            get { return CallContext.GetData(CallContextKey) as IncludeScope; }
        }
     
        private bool _disposed;
     
        protected virtual bool IsDisposed
        {
            get
            {
                return _disposed;
            }
        }
     
        ~IncludeScope()
        {
            Dispose(false);
        }
     
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
     
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed) {
                if (disposing) {
                    CallContext.SetData(CallContextKey, oldValue);
                }
                _disposed = true;
            }
        }
    }
 
