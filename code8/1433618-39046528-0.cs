    class ThreadManager
    {
        private ManualResetEvent shutdown = new ManualResetEvent(false);
        private Thread thread;
        public void start ()
        {
            thread = new Thread(MyThreadFunc);
            thread.Name = "MyThreadFunc";
            thread.IsBackground = true; 
            thread.Start();
        }
        public void Stop ()
        {
            shutdown.Set();
            if (!thread.Join(2000)) //2 sec to stop 
            { 
                thread.Abort();
            }
        }
        void MyThreadFunc ()
        {
            int i = 0;
            while (!shutdown.WaitOne(0))
            {
                // call with the work you need to do
                try {
                        RuntimeHelpers.PrepareConstrainedRegions();
                        try { }
                        finally
                        {
                            // do something not to be aborted
                        }
                    }
                    catch (ThreadAbortException e)
                    {
                            // handle the exception 
                    }
            }
        }
    }
