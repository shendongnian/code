    public static readonly object Lock1 = new object();
    public static readonly object Lock2 = new object();
    static void Main(string[] args)
    {
        new Thread(() =>
        {
            Console.WriteLine("Thread.PreLock2");
            lock (Lock2)
            {
                Console.WriteLine("Thread.PostLock2");
                Thread.Sleep(1000);
                Console.WriteLine("Thread.PreLock1");
                lock (Lock1)
                {
                    Console.WriteLine("Thread.PostLock1");
                    Console.WriteLine("****Thread.Finished****");
                }
            }
        }).Start();
        Console.WriteLine("Main.PreLock1");
        lock (Lock1)
        {
            Console.WriteLine("Main.PostLock1");
            Thread.Sleep(1000);
            Console.WriteLine("Main.PreLock2");
            lock (Lock2)
            {
                Console.WriteLine("Main.PostLock2");
                Console.WriteLine("****Main.Finished****");
            }
        }
    }
