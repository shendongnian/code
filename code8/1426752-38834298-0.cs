    class CancellationException : Exception
    {
        public object State { get; private set; }
        public CancellationException(object state)
        {
            this.State = state;
        }
    }
    private void DoSomething()
    {
        if (_worker.CancellationPending)
        {
            throw new CancellationException("cancelled from blah blah");
        }
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
            DoSomething();
        }
        catch (CancellationException ce)
        {
            e.Cancel = true;
        }
    }
