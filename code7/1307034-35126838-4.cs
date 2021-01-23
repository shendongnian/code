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
                    Task.Run(() => JobDispatcher(6000, "task 1")),
                    Task.Run(() => JobDispatcher(5000, "task 2")),
                    Task.Run(() => JobDispatcher(4000, "task 3")),
                    Task.Run(() => JobDispatcher(3000, "task 4")),
                    Task.Run(() => JobDispatcher(2000, "task 5")),
                    Task.Run(() => JobDispatcher(1000, "task 6"))
                );
            }
            public static async Task JobDispatcher(int time, string query)
            {
                var results = await Task.WhenAll(
                    Task.Run(() => worker(time, query + ": Subtask 1")),
                    Task.Run(() => worker(time, query + ": Subtask 2")),
                    Task.Run(() => worker(time, query + ": Subtask 3"))
                );
                Console.WriteLine(string.Join("\n", results));
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
