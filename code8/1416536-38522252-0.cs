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
        class Program
        {
            static void DoWork(CancellationToken ct)
            {
                for (int i = 0; i < 10; i++)
                {
                    // Check for cancellation on each iteration
                    if (ct.IsCancellationRequested) return;
                    // Do something
                    Console.WriteLine("Thread[{0}]: {1}", Thread.CurrentThread.ManagedThreadId, i);
                    // Wait on CancellationToken. If cancel be called, WaitOne() will immediatly return control!
                    // You can see it by Cancelled in 
                    ct.WaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                }
            }
            static void ThreadProc(object state)
            {
                ThreadObject to = (ThreadObject)state;
                try{
                    DoWork(to.CancellationToken);
                }
                finally{
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
                Console.WriteLine("Waiting thread exiting {0}. Wait result: {1}. Cancelled in {2}", MAX_THREAD_EXITING_TIMEOUT, isOk, sw.Elapsed);
                
                // If we couldn't stop thread in elegant way, just abort it
                if (!isOk)
                    thread.Abort();
            }
        }
    }
