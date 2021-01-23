    private IFoo Pop()
    {
        IFoo p;
        _stack.TryPop(out p);
        if (p == null)
        {
            p = RunFactory();   // this is lazy initialization of the stack
        }
        if (MaximumLoanTime > 0)
        {
            p.CurrentToken = new CancellationTokenSource();
            Task.Delay(MaximumLoanTime, p.CurrentToken.Token).ContinueWith(() =>
            {
                    p.CurrentToken.Dispose();
                    p.OnLoanExpired();
            }, TaskContinuationOptions.NotOnCanceled);
        }
        return p;
    }
