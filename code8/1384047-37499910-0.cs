    using System;
    using System.Threading;
    
    namespace ThreadPoolRegisterWaitForSingleObject
    {
        class Program
        {
            static void Main(string[] args)
            {
                var allTasksWaitHandle = new AutoResetEvent(false);
    
                Action action = () =>
                {
                    Console.WriteLine($"Long task running on {(Thread.CurrentThread.IsThreadPoolThread ? "thread pool" : "foreground")} thread Id: {Thread.CurrentThread.ManagedThreadId}");
    
                    for (int i = 0; i < 1000000; i++)
                        for (int j = 0; j < 100000000; j++) ;
                };
    
                //var result = action.BeginInvoke((state) =>
                //{
                //    Console.WriteLine("Async call back says long thing done.");
                //}, null);
    
                var result = action.BeginInvoke(null, null);
    
                Console.WriteLine("Main thread not blocked.");
    
                var registerWaitHandle = ThreadPool.RegisterWaitForSingleObject(result.AsyncWaitHandle, (s, b) =>
                {
                    Console.WriteLine("Main long task finished.");
                    Console.WriteLine($"WaitOrTimerCallback running on {(Thread.CurrentThread.IsThreadPoolThread ? "thread pool" : "foreground")} thread Id: {Thread.CurrentThread.ManagedThreadId}");
    
                    allTasksWaitHandle.Set();
                }, null, 5000, true);
    
                allTasksWaitHandle.WaitOne();
    
                Console.WriteLine("All threads done.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
