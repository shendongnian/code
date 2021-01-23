    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        internal class Program
        {
            public static void Main()
            {
                var queue = new ConcurrentQueue<int>();
                Task.Run(() =>
                {
                    for (int i = 0; i < 1000; ++i)
                    {
                        queue.Enqueue(i);
                        Thread.Sleep(1);
                    }
                });
                Thread.Sleep(100);
                Console.WriteLine($"Count before loop: {queue.Count}");
                foreach (var i in queue)
                    Console.WriteLine($"{i}, n={queue.Count}");
            }
        }
    }
