        class Foo
        {
            private readonly object syncLock = new object();
            private bool dataAvailable = false;
    
            public void ThreadProc1()
            {
                lock(syncLock)
                {
                    while(!dataAvailable)
                    {
                        // Release the lock and suspend
                        Monitor.Wait(syncLock);
                    }
    
                    // Now process the data
                }
            }
    
            public void ThreadProc2()
            {
                LoadData();
    
                lock(syncLock)
                {
                    dataAvailable = true;
                    Monitor.Pulse(syncLock);
                }
            }
    
            private void LoadData()
            {
                // Gets some data
            }
        }
    }
