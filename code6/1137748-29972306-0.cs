    static void Main(string[] args)
    {
        var lockObject = new object();
        var fileName = @"C:\Users\kevin\Documents\test.txt";
        Action<object> action1 = (o) =>
        {
            var i = 0;
            while (i++ < 1000)
            {
                // do stuff that doesn't require the lock
                lock (o)
                {
                    Console.WriteLine("In Thread1");
                    // do stuff that does require the lock
                    var text = File.ReadAllText(fileName);
                    Console.WriteLine(text);
                    File.WriteAllText(fileName, "\tThread1");
                }
            }
        };
        // Pass in our shared lock object
        Task task1 = new Task(action1, lockObject);
        task1.Start();
        Action<object> action2 = (o) =>
        {
            var i = 0;
            while (i++ < 1000)
            {
                // do stuff that doesn't require the lock
                lock (o)
                {
                    // do stuff that does require the lock
                    Console.WriteLine("In Thread2");
                    var text = File.ReadAllText(fileName);
                    Console.WriteLine(text);
                    File.WriteAllText(fileName, "\tThread2");
                }
            }
        };
        // Pass in our shared lock object
        Task task2 = new Task(action2, lockObject);
        task2.Start();
    
        // sleep main thread and let the 2 threads do their stuff
        Thread.Sleep(5000);
    
        Console.ReadLine();
    }
