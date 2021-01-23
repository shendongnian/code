    public ManualResetEvent finalizing { get; set; }
    public void Flush()
    {
        finalizing.WaitOne();
    }
