        private static readonly Dictionary<int, object> DocumentLocks = new Dictionary<int, object>();
        private static readonly object LockFetchDocument = new object();
        public static void ExportDocument(int ID)
        {
            object DocumentLocker;
            lock (LockFetchDocument)
            {
                // Only access DocumentLocks inside this block
                if (DocumentLocks.ContainsKey(ID))
                {
                    DocumentLocker = DocumentLocks[ID];
                }
                else
                {
                    DocumentLocker = new object();
                    DocumentLocks[ID] = DocumentLocker;
                }
            }
            
            bool lockTaken = false;
            try
            {
                System.Threading.Monitor.TryEnter(DocumentLocker, ref lockTaken);
                if (!lockTaken)
                {
                    // Export is already running, wait for it to finish then return
                    System.Threading.Monitor.Enter(DocumentLocker, ref lockTaken);
                    // When we return the finally block will still be executed and release the lock
                    return;
                }
                // Do stuff
            }
            finally
            {
                if (lockTaken)
                    System.Threading.Monitor.Exit(DocumentLocker);
            }
        }
