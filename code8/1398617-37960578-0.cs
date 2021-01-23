    namespace RunSafe
    {
        // Declare a delegate type
        public delegate void RunSafeDelegate();
    
        public class SafeRunner
        {
            private object _lock =  new Object();
            public void Runner( RunSafeDelegate runsafe )
            {
                lock( this._lock )
                {
                    runsafe();
                }
            }
        }
    }
