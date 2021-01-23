    using System;
    using System.Threading;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                doAsync();
                Thread.Sleep(2000);
                Console.WriteLine("Did we finish?"); // Likely this is never displayed.
            }
            public static unsafe void doAsync()
            {
                int n = 10000;
                var arr = stackalloc int[n];
                    ThreadPool.QueueUserWorkItem(x => {
                    Thread.Sleep(1000);
                
                    for (int i = 0; i < n; ++i)
                        arr[i] = 0;
                });
            }
        }
    }
