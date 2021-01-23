    void Foo()
    {
        Func1();
        // do other stuff
    }
    
    void Func1()
    {
        Func2().Wait();  // Synchronously blocking a thread.
        // do other stuff
    }
    
    async Task Func2()
    {
        await tcpClient.SendAsync();
        // do other stuff
    }
