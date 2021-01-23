    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication4
    {
     class Program
     {
        static CancellationTokenSource tokenSource2;
        static CancellationToken ct;
        static void Main(string[] args)
        {
            tokenSource2 = new CancellationTokenSource();
            ct = tokenSource2.Token;
            Task myTask = new Task(BuildZipFile);
            myTask.Start();
            Console.WriteLine("Press enter to cancel");
            Console.ReadLine();
            tokenSource2.Cancel();
            Console.ReadLine();
        }
        public static void BuildZipFile()
        {
            Task quick1 = new Task(DoQuickUncancelableThings);
            quick1.ContinueWith(ant => DoLongRunnignThings(), ct).ContinueWith(ant => DoMoreQuickUncancelableThings());
            quick1.Start();
        }
        private static void DoMoreQuickUncancelableThings()
        {
            Console.WriteLine("Q2");
        }
        private static void DoLongRunnignThings()
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(1000);
                ct.ThrowIfCancellationRequested();
            }
            Console.WriteLine("Long ended");
        }
        private static void DoQuickUncancelableThings()
        {
            Console.WriteLine("Q1");
        }
     }
    }
