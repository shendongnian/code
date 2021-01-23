    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using static System.Console;
    
    public static class Program
    {
        const int N = 20;
        static readonly object obj = new object();
        static int counter;
    
        public static void Job(ConsoleColor color, int multiplier = 1)
        {
            for (long i = 0; i < N * multiplier; i++)
            {
                lock (obj)
                {
                    counter++;
                    ForegroundColor = color;
                    Write($"{Thread.CurrentThread.ManagedThreadId}");
                    if (counter % N == 0) WriteLine();
                    ResetColor();
                }
                Thread.Sleep(N);
            }
        }
           
        static async Task JobAsync()
        {
           // intentionally removed
        }
    
        public static async Task Main()
        {
           // intentionally removed
        }
    }
