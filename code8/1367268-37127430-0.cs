    using System;
    using System.Threading;
    
    class Program {
        static void Main(string[] args) {
            new Thread(Example).Start();
            new Thread(Example).Start();
            Console.ReadLine();
        }
        static void Example() {
            var rng = new Random(Thread.CurrentThread.ManagedThreadId);
            for (int loop = 0; loop < 10000; ++loop) {
                Thread.Sleep(rng.Next(0, 100));
                Thread.Sleep(rng.Next(0, 100));
                Thread.Sleep(rng.Next(0, 100));
                Thread.Sleep(rng.Next(0, 100));
                Thread.Sleep(rng.Next(0, 100));
                Thread.Sleep(rng.Next(0, 100));
                Thread.Sleep(rng.Next(0, 100));
            }
        }
    }
