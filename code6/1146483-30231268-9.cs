    private CancellationTokenSource tokenSource = new CancellationTokenSource();
    private void OnExit(..)
    {
        tokenSource.Cancel();
    }
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        //whatever You want the background thread to do...
        SomeClass.SomeStaticMethodWhichHasLoopInside(tokenSource.Token);
    }
    class SomeClass
    {
        public static void SomeStaticMethodWhichHasLoopInside(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                //Do something
            }
        }
    }
