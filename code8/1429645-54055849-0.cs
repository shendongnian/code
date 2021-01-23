    //Your async operation
    public IAsyncOperation<object> Operation()
    {
        //Doing some important stuff
    }
    public void Initialize()
    {
        Task op = Operation().AsTask();
        op.Wait();
        object results = op.Result;    //Here's our result
    }
