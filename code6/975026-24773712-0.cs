    // This is the object that we lock to control access
    private static object _intervalSync = new object();
    private void OnElapsedTime(object sender, ElapsedEventArgs e)
    {       
        if (System.Threading.Monitor.TryEnter(_intervalSync))
        {
            try
            {
                // Your code here
            }
            finally
            {
                // Make sure Exit is always called
                System.Threading.Monitor.Exit(_intervalSync);
            }
        }
        else
        {
            //Previous interval is still in progress.
        }
    }
