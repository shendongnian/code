    private void ThreadProc()
    {
        while (true)
        {
            string inData = _queue.Dequeue();
            this.Invoke(new SetGridDeleg(DoUpdate), new object[] {inData});
        }
    }
