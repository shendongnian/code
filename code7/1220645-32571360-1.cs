    private static int Main()
    {
        Task.Factory.StartNew(async ()=> await InitAsync());
        m_waitInitCompletedRequest.WaitOne(TimeSpan.FromSeconds(30));
        return (int)EndpointErrorCode.Ended;
    }
