    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                int max = 50;
                int delay = 30; // ~30s per work item
    
                ThreadPool.SetMaxThreads(max, max);
    
                Console.WriteLine("starting, threads: {0}", Process.GetCurrentProcess().Threads.Count);
    
                var tasks = Enumerable.Range(0, max).Select(n => Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("task: {0}, threads: {1}, pool thread: {2}", 
                        n, Process.GetCurrentProcess().Threads.Count, Thread.CurrentThread.IsThreadPoolThread);
    
                    for (int i = 0; i < delay * 1000; i++)
                    {
                        Thread.Sleep(1);
                    }
                })).ToArray();
    
                Console.WriteLine("waiting, threads: {0}", Process.GetCurrentProcess().Threads.Count);
                Task.WaitAll(tasks);
    
                Console.WriteLine("done, threads: {0}", Process.GetCurrentProcess().Threads.Count);
                Console.ReadLine();
            }
        }
    }
