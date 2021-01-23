    private void runJobThread(string strBox, string strJob, CancellationToken token)
    {
       Thread t = Thread.CurrentThread;
        using (token.Register(t.Abort))
        {
        // CODE ...
        sapLocFunction.Call(); // When this line is running I cannot cancel the process
        // CODE ...
       } 
    }
