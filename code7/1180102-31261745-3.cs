    public void StartCount(int input, CancellationToken token)
    {
        SomeData = input;
        while (input > 0 && !token.IsCancellationRequested)
        {
            System.Threading.Thread.Sleep(1000);
            input -= 1;
            SomeData = input;
        }
    }
    IAsyncResult process;
    public void Begin(int input)
    {
        if (process != null && !process.IsCompleted)
            ((CancellationTokenSource)process.AsyncState).Cancel();
        Action<int, CancellationToken> Start = new Action<int, CancellationToken>(StartCount);
        var cancelSource = new CancellationTokenSource();
        process = Start.BeginInvoke(input,cancelSource.Token, null, cancelSource);
    }
