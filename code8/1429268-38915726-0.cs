    using System.Diagnostics;
    using System.Threading;
    
    public class Fibonacci
    {
        public void ThreadPoolCallback(object threadContext)
        {
            FibOfN = Calculate(N);
            DoneEvent.Set();
        }
    
        public int Calculate(int n)
        {
            if (n <= 1) return n;
            return Calculate(n - 1) + Calculate(n - 2);
        }
    
        public int N { get; set; }
        public int FibOfN { get; private set; }
        public ManualResetEvent DoneEvent { get; set; }
    }
    
    public class ClrSemaphoreWaitDemo
    {
        static void Main()
        {
            const int numberOfTasks = 12;
            var doneEvents = new ManualResetEvent[numberOfTasks];
            var fibArray = new Fibonacci[numberOfTasks];
            ThreadPool.SetMaxThreads(numberOfTasks, numberOfTasks);
            ThreadPool.SetMinThreads(numberOfTasks, numberOfTasks);
    
            for (int i = 0; i < numberOfTasks; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                fibArray[i] = new Fibonacci {N= 4, DoneEvent= doneEvents[i]};
                ThreadPool.QueueUserWorkItem(fibArray[i].ThreadPoolCallback, i);
            }
    
            WaitHandle.WaitAll(doneEvents);
            Debug.WriteLine("Now run .symfix; .reload; .loadby sos clr; !threads; !threads; !findstack clr!CLRSemaphore::Wait");
            Debugger.Break();
        }
    }
