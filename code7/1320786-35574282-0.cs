    class Worker
    {
        private int isRunning = 0;
     
        public void DoWork()
        {
            if (Interlocked.CompareExchange(ref isRunning, 1, 0) == 0)
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
