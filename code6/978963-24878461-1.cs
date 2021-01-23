    private static Queue<string> filesToCheck = new Queue<string>();
    private System.Timers.Timer copyTimer;
    public void Search()
    {
        try
        {
            foreach (string file in Directory.EnumerateFiles(@"C:\Users\user\Downloads\MCFILE\trrtrt\", "*.exe", SearchOption.AllDirectories))
            {
                // Display file path.
                if (SHA1Hash.GetSHA1Hash(file) == "1233456") // fake SHA1Hash
                {
                    if (!TryToCopy(file))  // See function below
                    {
                        filesToCheck.Enqueue(file);
                    }
                }
            }
            // Checked all the files once.
            // If there are any in the queue, start the timer.
            if (filesToCheck.Count > 0)
            {
                copyTimer = new System.Timers.Timer(CopyTimerProc, null, 1000, Timeout.Infinite);
            }
            
        }
        catch (Exception)
        {
            // do your error handling
        }
    }
    private void CopyTimerProc(object state)
    {
        string filename = filesToCheck.Dequeue();
        if (TryToCopy(filename))
        {
            // success. If the queue is empty, kill the timer.
            if (filesToCheck.Count == 0)
            {
                copyTimer.Dispose();
            }
        }
        else
        {
            // File still locked.
            // Put it back on the queue and reset the timer.
            filesToCheck.Enqueue(filename);
            copyTimer.Change(1000, 0);
        }
    }
    private bool TryToCopy(string filename)
    {
        try
        {
            COPYWithReplace(@"C:\Users\user\Downloads\MCFILE\Fake2\Test.exe", filename);
            return true;
        }
        catch (IOException)
        {
            // log error
            return false;
        }
    }
