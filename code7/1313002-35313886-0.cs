    ConcurrentQueue<MyObject> m_Responses=new ConcurrentQueue<MyObject>();
    public async Task MyPollMethod(int interval)
    {
        while(...)
        {
            var result=await SomeAsyncCall();
            m_Responses.Enqueue(result);
            await Task.Delay(interval);
        }
    }
