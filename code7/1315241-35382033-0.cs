    // NOTE: this loop will block your main GUI thread so it might be
    // a good idea not to wait too long by having a timeout mechanism
    Process process=null;
    do
    {
        Thread.Sleep(0);  // be nice to CPU
        Process[] items = Process.GetProcessesByName("AB"); //this is the exe file
        if (items.Length == 1)
        {
            process = items[0];
        }
        // break if taking too long
    }
    while (process == null);
    // if process is still null then we timed out.  handle appropriately
    _wait_debug.ShowDialog(); // Show() doesn't work either
    _wait_debug.TopMost = true;
