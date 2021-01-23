    void MyMethod()
    {
        Thread[] threads = new Thread[Environment.ProcessorCount - 1];
        for (int i = 0; i < Environment.ProcessorCount - 1; i++)
        {
            int local = i;
            threads[i] = new Thread(() => FillObjects(local));
            threads[i].Priority = ThreadPriority.AboveNormal;
            threads[i].Start();
        }
        while (threads.Any(c => c.IsAlive))
        {
            Thread.Sleep(50);
        }
    }
