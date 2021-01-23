    using (Mutex mut = new Mutex(false, MUTEX_NAME))
    {
        if (mut.WaitOne(new TimeSpan(0, 0, 30)))
        {
            try
            {
               // Some code that deals with a specific TCP port
               // Don't want this to run twice in multiple processes        
            }
            catch(Exception)
            {
               // Handle exceptions and clean up state
            }
            finally
            {
                mut.ReleaseMutex();
            }
        }
    }
