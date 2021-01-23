    ManualResetEvent mre = new ManualResetEvent(false);
    MyExec.OutputDataReceived += new DataReceivedEventHandler(
            (s, e) =>
            {
                if (String.IsNullOrWhiteSpace(e.Data) || e.Data.Contains('X'))
                    mre.Set();
            });
    ...
    //On the other thread
    //This will wait until the ManualResetEvent is signaled via mre.Set();
    mre.WaitOne(); 
