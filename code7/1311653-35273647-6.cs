    public struct SyncObject
    {
        public int SomeField;
    }
    
    public delegate void SyncHandler(SyncObject s);
    
    public class Synchronizer
    {
        public event SyncHandler OnSynchronization;
    
        private SynchronizationContext _context;
    
        public Synchronizer()
        {
            this._context = new SynchronizationContext();
        }
    
        public void PostUpdate(SyncObject o)
        {
            var handleNullRefs = this.OnSynchronization;
            if ( handleNullRefs != null )
            {
                this._context.Post(state => handleNullRefs((SyncObject)state), o);
            }
        }
    }
    
    public class Foo
    {
        private Synchronizer _sync;
        public Foo(Synchronizer s)
        {
            this._sync = s;
        }
        private void Method1(object state)
        {
            var token = (CancellationToken) state;
            while ( !token.IsCancellationRequested )
            {
                //do things
                this._sync.PostUpdate(new SyncObject());
            }
    
        }
    }
