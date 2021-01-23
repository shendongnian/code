    public interface IMyClass { int Level { get; } } // whatever
    public class MyClassFactory {
        private delegate void Notifier(int level);
        public class MyClass : IDisposable
        {
            public MyClass(int level, Notifier notifier)
            {
               _level = level;
               _notifier = notifier;
            }
            private int _level;
            private Notifier _notifier;   
            ~MyClass() { Dispose(false); }
            public int Level { get { return level; } }
            public Dispose() { Dispose(true); GC.SuppressFinalize(this); }
            private bool _disposed = false;
            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed) {
                    if (disposing) {
                        notifier(Level);
                        _disposed = false;
                    }
                    else { throw new Exception("My class used outside using block."); }
                }
            }
        }
        private int _level = 0;
        public IMyClass Make()
        {
            return new MyClass(_level++,
                    childLevel => {
                       if (childLevel == _level)
                           --_level;
                       else throw new Exception("Disposed out of order.");
                     });
        }        
    }
