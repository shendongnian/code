        using System;
        using System.Threading.Tasks;
        class ThreadTest
        {    
           public static int sum {get; set;}
        }
        static void Main()
        {
         
         Parallel.For(0, 1, i =>
        {
            // Some thread instrumentation
            Console.WriteLine("i = {0}, thread = {1}", i,
            Thread.CurrentThread.ManagedThreadId);
            
            Interlocked.Increment(ref ThreadTest.sum);
        });
           Console.WriteLine(ThreadTest.sum.ToString());
           Console.ReadLine();
        }
        }
