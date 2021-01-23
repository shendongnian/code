    // These fields will work together to provide a way for the thread to interrupt
    // itself temporarily without actually using a thread at all.
    private TaskCompletionSource<object> _pause;
    private readonly object _pauseLock = new object();
    private void button2_Click(object sender, DoWorkEventArgs e)
    {
        // Initialize ProgressBar. Note: in your version of the code, this was
        // done in the DoWork event handler, but that handler isn't executed in
        // the UI thread, and so accessing a UI object like progressBar1 is not
        // a good idea. If you got away with it, you were lucky.
        progressBar1.Minimum = 0;
        progressBar1.Maximum = 100000;
        progressBar1.Value = 0;
        // This object will perform the duty of the BackgroundWorker's
        // ProgressChanged event and ReportProgress() method.
        Progress<int> progress = new Progress<int>(i => progressBar1.Value++);
        // We do want the code to run in the background. Use Task.Run() to accomplish that
        Task.Run(async () =>
        {
            for (int i = 0; i < 100000; i++)
            {
                progress.Report(i);
                Task task = null;
                // Locking ensures that the two threads which may be interacting
                // with the _pause object do not interfere with each other.
                lock (_pauseLock)
                {
                    if (i == 50000)
                    {
                        // We want to pause. But it's possible we lost the race with
                        // the user, who also just pressed the pause button. So
                        // only allocate a new TCS if there isn't already one
                        if (_pause == null)
                        {
                            _pause = new TaskCompletionSource<object>();
                        }
                    }
                    // If by the time we get here, there's a TCS to wait on, then
                    // set our local variable for the Task to wait on. In this way
                    // we resolve any other race that might occur between the time
                    // we checked the _pause object and then later tried to wait on it
                    if (_pause != null)
                    {
                        task = _pause.Task;
                    }
                }
                if (task != null)
                {
                    // This is the most important part: using "await" tells the method to
                    // return, but in a way that will allow execution to resume later.
                    // That is, when the TCS's Task transitions to the completed state,
                    // this method will resume executing, using any available thread
                    // in the thread pool.
                    await task;
                    // Once we resume execution here, reset the TCS, to allow the pause
                    // to go back to pausing again.
                    lock (_pauseLock)
                    {
                        _pause.Dispose();
                        _pause = null;
                    }
                }
            }
        });
    }
    private void button1_Click(object sender, EventArgs e)
    {
        lock (_pauseLock)
        {
            // A bit more complicated than toggling a flag, granted. But it achieves
            // the desirable goal.
            if (_pause == null)
            {
                // Creates the object to wait on. The worker thread will look for
                // this and wait if it exists.
                _pause = new TaskCompletionSource<object>();
            }
            else if (!_pause.Task.IsCompleted)
            {
                // Giving the TCS a result causes its corresponding Task to transition
                // to the completed state, releasing any code that might be waiting
                // on it.
                _pause.SetResult(null);
            }
        }
    }
