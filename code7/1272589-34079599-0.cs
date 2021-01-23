    void ThisMethodIsCalledFromASPNet()
    {
        Task.Factory.StartNew( 
            ctx => DoSomething((HttpContext)ctx),
            System.Web.HttpContext.Current,
            CancellationToken.None, 
            TaskCreationOptions.None, 
            TaskScheduler.FromCurrentSynchronizationContext());
    }
    void DoSomething(HttpContext ctx)
    {
        // ctx is your HttpContext
    }
