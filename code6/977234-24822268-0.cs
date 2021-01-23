    public void DoWork()
    {
        // queue in a loop
        System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(YourDatabaseWork));
    }
    
    private void YourDatabaseWork(Object state)
    {
        // Insert code to perform a long task.
    }
