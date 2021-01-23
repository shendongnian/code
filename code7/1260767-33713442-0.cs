    using System;
    using System.Threading;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                var ts = new ThreadStart(BackgroundMethod);
                var backgroundThread = new Thread(ts);
                backgroundThread.Start();
    
                // Main calculations here.
                int j = 10000;
                while (j > 0)
                {
                    Console.WriteLine(j--);
                }
                // End main calculations.
            }
    
            private static void BackgroundMethod()
            {
                // Background calculations here.
                int i = 0;
                while (i < 100000)
                {
                    Console.WriteLine(i++);
                }
                // End background calculations.
            }
        }
    }
