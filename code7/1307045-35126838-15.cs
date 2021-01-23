    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                // ThreadPool.SetMinThreads(20, 20);
                var sw = Stopwatch.StartNew();
                Console.WriteLine("Waiting for all tasks to complete");
                RunWorkers().Wait();
                Console.WriteLine("All tasks completed in " + sw.Elapsed);
            }
            public static async Task RunWorkers()
            {
                await Task.WhenAll(
                    JobDispatcher(6000, "task 1"),
                    JobDispatcher(5000, "task 2"),
                    JobDispatcher(4000, "task 3"),
                    JobDispatcher(3000, "task 4"),
                    JobDispatcher(2000, "task 5"),
                    JobDispatcher(1000, "task 6")
                );
            }
            public static async Task JobDispatcher(int time, string query)
            {
                var results = await Task.WhenAll(
                    worker(time, query + ": Subtask 1"),
                    worker(time, query + ": Subtask 2"),
                    worker(time, query + ": Subtask 3")
                );
                Console.WriteLine(string.Join("\n", results));
            }
            static async Task<string> worker(int time, string query)
            {
                return await Task.Run(() =>
                {
                    Console.WriteLine("Starting worker " + query);
                    Thread.Sleep(time);
                    Console.WriteLine("Completed worker " + query);
                    return query + ": " + time + ", thread id: " + Thread.CurrentThread.ManagedThreadId;
                });
            }
        }
    }
