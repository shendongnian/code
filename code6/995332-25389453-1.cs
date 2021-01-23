    private TcpClient client = new TcpClient();
    private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
    public void BeginRead()
    {
        semaphore.WaitAsync()
            .ContinueWith(t =>
                client.GetStream()
                .BeginRead(null, 0, 0, Read_Callback, null));
    }
    private void Read_Callback(IAsyncResult ar)
    {
        client.GetStream().EndRead(ar);
        semaphore.Release();
        BeginRead();
    }
