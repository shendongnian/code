    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                for (int it = 0; it < 10; ++it)
                {
                    Console.WriteLine($"\nStarting iteration {it}");
                    Task[] tasks = new Task[5];
                    for (int i = 0; i < 5; ++i)
                        tasks[i] = Task.Run(demoTask);
                    Task.WaitAll(tasks);
                }
            
                Console.WriteLine("\nFinished");                  
                Console.ReadLine();
            }
            static async Task demoTask()
            {
                int id = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"Thread {id} starting");
                bool firstIn = await taskWrapper();
                Console.WriteLine($"Task {id}: executed: {firstIn}");
            }
            static async Task<bool> taskWrapper()
            {
                bool firstIn = await signal.WaitAsync(0);
                if (firstIn)
                {
                    await baseTask();
                    signal.Release();
                }
                else
                {
                    await signal.WaitAsync();
                    signal.Release();
                }
                return firstIn;
            }
            static async Task baseTask()
            {
                Console.WriteLine("Starting long method.");
                await Task.Delay(1000);
                Console.WriteLine("Finished long method.");
            }
            static readonly SemaphoreSlim signal = new SemaphoreSlim(1, 1);
        }
    }
