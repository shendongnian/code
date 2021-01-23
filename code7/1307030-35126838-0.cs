    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                // By default creating threads in the threadpool is throttled.
                // If you run this code unmodified, it's likely that you'll see
                // the same threadpool thread being used for multiple threads.
                // However, if you uncomment the line below, you'll see that
                // more threads are used.
                // NOTE: Setting the ThreadPools minimum thread count is considered
                // a bad design.
                // ThreadPool.SetMinThreads(20, 20);
                var results = runWorkers(18).Result;
                Console.WriteLine(string.Join("\n", results));
            }
            static async Task<string[]> runWorkers(int n)
            {
                var workers = new Task<string>[n];
                for (int i = 0; i < n; ++i)
                {
                    int j = i;
                    workers[i] = Task.Run(() => worker(1000 + (n-j)*100, j.ToString()));
                }
                return await Task.WhenAll(workers);
            }
            static async Task<string> worker(int time, string query)
            {
                Console.WriteLine("Starting worker " + query);
                await Task.Delay(time);
                Console.WriteLine("Completed worker " + query);
                return query + ": " + time + ", thread id: " + Thread.CurrentThread.ManagedThreadId;
            }
        }
    }
