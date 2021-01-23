    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication2
    {
        static class Program
        {
            private static void Main()
            {
                var task = Task.Run(() => task1());
                task = task.ContinueWith(antecedant => task2());
                Console.WriteLine("Waiting for composite task to complete.");
                task.Wait();
                Console.WriteLine("Composite Task completed.");
            }
            private static void task1()
            {
                Console.WriteLine("Starting task 1");
                Thread.Sleep(2000);
                Console.WriteLine("Ending task 1");
            }
            private static void task2()
            {
                Console.WriteLine("Starting task 2");
                Thread.Sleep(2000);
                Console.WriteLine("Ending task 2");
            }
        }
    }
