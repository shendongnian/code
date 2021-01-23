    public static void ThreadDoWork()
    {
        using (var dispose = new ThreadDispose())
        { 
            dispose.RunAsync();
        }
    }
    public void RunAsync ()
    {
        ThreadPool.QueueUserWorkItem(state =>
        {
            Thread.Sleep(3000);
        });
    }
