    using System;
    using System.Threading;
    
    namespace Chapter1
    {
        public static class Threads1
        {
            public static void ThreadMethod()
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("ThreadProc: {0}", i);
                    Thread.Sleep(1);
                }
            }
            public static void Main(string[] args)
            {
                Thread t = new Thread(new ThreadStart(ThreadMethod));
                t.Start();
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("Main thread: Do some work.");
                    Thread.Sleep(1);
                }
                t.Join();
    
                Console.Read();
            }
        }
    }
    // OUTPUT:
    //Main thread: Do some work.
    //ThreadProc: 0
    //ThreadProc: 1
    //Main thread: Do some work.
    //ThreadProc: 2
    //Main thread: Do some work.
    //ThreadProc: 3
    //Main thread: Do some work.
    //ThreadProc: 4
    //ThreadProc: 5
    //ThreadProc: 6
    //ThreadProc: 7
    //ThreadProc: 8
    //ThreadProc: 9
