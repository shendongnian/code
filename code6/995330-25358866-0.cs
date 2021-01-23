    TcpClient client = new TcpClient();
    private static readonly Semaphore Semaphore = new Semaphore(1, 1);
    public void BeginRead()
    {
        if (!Semaphore.WaitOne(0))
        {
            return;
        }
        client.GetStream().BeginRead(..., Read_Callback);
    }
    private void Read_Callback(IAsyncResult ar)
    {
        client.GetStream().EndRead(ar);
        Semaphore.Release();
        BeginRead();
    }
