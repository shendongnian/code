    for (int i = 0 ; i < 26 ; i++)
    {
        Task.Run(
            () =>
            {
                DoSomething(i);
            }
        );
        Thread.Sleep(TimeSpan.FromMinutes(1));
    }
