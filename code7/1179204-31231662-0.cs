    private ManualResetEvent _mre = new ManualResetEvent(false);
    private void ReadTheDatabase()
    {
        Thread startUpload = new Thread(() =>
        {
            // Read the data
            foreach (DataRow dr in dt.Rows)
            {
                // Send request
                RequestMethod();
                _mre.WaitOne(30000, false);
            }
        });
        startUpload.Start();
    }
    private void RequestMethod()
    {
        // Doing something here
        _mre.Set();
    }
