    public class Context: IDisposable
    {
        public Context
        {
            Contexts.ContextCreated(this);
        }
        public void Dispose
        {
            Contexts.ContextDisposed(this);
        }
    }
