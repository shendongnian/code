    using (var sa = new SampleActor())
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(await sa.GetThreadStatusAsync());
            Console.WriteLine("Continue on thread :" + Thread.CurrentThread.ManagedThreadId);
        }
    }
