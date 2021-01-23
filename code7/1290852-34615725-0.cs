    public void Start(Action action)
    {
        ... // 1
        ThreadPool.QueueUserWorkItem(o =>
        {
            ... // 2
            action();
            ... // 3
       
        });
        ... // 4
    }
