        void DoWork(object o)
        {           
            SynchronizationContext cont = o as SynchronizationContext;
            // your logic gere
            cont.Post(delegate
            {
                // all your UI updates here 
            }, null);
        }
       Thread workerThread = new Thread(DoWork);
       workerThread.Priority = ThreadPriority.Highest;
       workerThread.Start(SynchronizationContext.Current);
