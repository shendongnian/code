    public class Test
    {
        private static readonly object _syncLock = new object();
    
        public void MyMethod() 
        {
             lock(_syncLock)
             {
                // No more than a thread will be able to work within this
                // protected code block. Others will be awaiting/blocked until
                // the thread that acquired the lock leaves this code block
             }
        }
    }
