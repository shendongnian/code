    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                var numbersToProcess = Enumerable.Range(1, 1000);
                foreach (int number in numbersToProcess)
                {
                    int n = number;
                    Task.Run(() => doStuff(n));
                }
                Console.ReadLine();
            }
            static void doStuff(int value)
            {
                Console.WriteLine("Thread {0} is processing {1}", Thread.CurrentThread.ManagedThreadId, value);
                Thread.Sleep(250); // Simulate compute-bound task.
            }
        }
    }
