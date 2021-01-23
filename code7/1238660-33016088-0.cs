    private void Process()
    {
        var result = HttpListener.BeginGetContext(ContextReceived, HttpListener);
        result.AsyncWaitHandle.WaitOne(30000);
        result.AsyncWaitHandle.Dispose();
    }
