    namespace ElegantThreadWork
    {
        using System;
        using System.Threading;
        using System.Diagnostics;
    
        class ThreadObject
        {
            public CancellationToken CancellationToken { get; private set; }
            public ManualResetEvent WaitHandle { get; private set; }
    
            public ThreadObject(CancellationToken ct, ManualResetEvent wh)
            {
                CancellationToken = ct;
                WaitHandle = wh;
            }
        }
        public class Program
        {
            static void DoWork(CancellationToken ct)
            {
                Console.WriteLine("Thread[{0}] started", Thread.CurrentThread.ManagedThreadId);
                int i = 0;
                // Check for cancellation on each iteration
                while (!ct.IsCancellationRequested)
                {
                    // Do something
                    Console.WriteLine("Thread[{0}]: {1}", Thread.CurrentThread.ManagedThreadId, i);
                    // Wait on CancellationToken. If cancel be called, WaitOne() will immediatly return control!
                    // You can see it by elapsed time
                    ct.WaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                    i++;
                }
                Console.WriteLine("Thread[{0}] has been cancelled", Thread.CurrentThread.ManagedThreadId);
            }
            static void ThreadProc(object state)
            {
                ThreadObject to = (ThreadObject)state;
                try
                {
                    DoWork(to.CancellationToken);
                }
                finally
                {
                    to.WaitHandle.Set();
                }
            }
            public static void Main(string[] args)
            {
                TimeSpan MAX_THREAD_EXITING_TIMEOUT = TimeSpan.FromSeconds(5);
    
                // Use for elegant thread exiting
                ManualResetEvent isThreadExitedEvent = new ManualResetEvent(false);
                CancellationTokenSource cts = new CancellationTokenSource();
                ThreadObject threadObj = new ThreadObject(cts.Token, isThreadExitedEvent);
    
                // Create thread
                Thread thread = new Thread(ThreadProc, 0);
                thread.Start(threadObj);
    
                Console.WriteLine("Just do something in main thread");
    
                Console.WriteLine("Bla.");
                Thread.Sleep(1000);
    
                Console.WriteLine("Bla..");
                Thread.Sleep(1000);
    
                Console.WriteLine("Bla...");
                Thread.Sleep(1000);
    
                Console.WriteLine("Thread cancelattion...");
                Stopwatch sw = Stopwatch.StartNew();
                // Cancel thread
                cts.Cancel();
    
                // Wait for thread exiting
                var isOk = isThreadExitedEvent.WaitOne(MAX_THREAD_EXITING_TIMEOUT);
                sw.Stop();
                Console.WriteLine("Waiting {0} for thread exiting. Wait result: {1}. Cancelled in {2}", MAX_THREAD_EXITING_TIMEOUT, isOk, sw.Elapsed);
    
                // If we couldn't stop thread in elegant way, just abort it
                if (!isOk)
                    thread.Abort();
            }
        }
    }
