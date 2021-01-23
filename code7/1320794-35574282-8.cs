    class Worker
    {
        private volatile int isRunning = 0;
     
        public void DoWork()
        {
            if (isRunning == 0 && Interlocked.CompareExchange(ref isRunning, 1, 0) == 0)
            {
                try
                {
                    DoTheMagic();
                }
                finally
                {
                    isRunning = 0;
                }
            }
        }
    
        private void DoTheMagic()
        {
            // do something interesting
        }
    }
