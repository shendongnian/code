    using (new Semaphore(0, 1, appName, out createNew))
    {
        if (createNew)
        {
            Console.WriteLine("One instance of MyApplication is created and running...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Only one instance of MyApplication can be running at a time... Auto shut down in 3 seconds...");
            Thread.Sleep(3000);
            return;
        }
    }
