      using System;
    using System.Threading;
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(ThreadOne).Start();
            new Thread(ThreadTwo).Start();
            Console.Read();
        }
        private static void ThreadOne(object obj)
        {
            Lifecycle.Start();
            Thread.Sleep(500);
            Lifecycle.Stop();
        }
        private static void ThreadTwo(object obj)
        {
            Thread.Sleep(600);
            Lifecycle.Start();
            Thread.Sleep(1800);
            Lifecycle.Stop();
        }
    }
    class Engine
    {
        public void Start()
        {
            Console.WriteLine("Engine was started");
        }
        public void Stop()
        {
            Console.WriteLine("Engine was stopped");
        }
    }
    static class Lifecycle
    {
        private static Engine Engine;
        private static int _counter = 0;
        static Lifecycle()
        {
            Engine = new Engine();
        }
        public static void Start()
        {
            Interlocked.Increment(ref _counter);
            lock (Engine)
            {
                Engine.Start();
                Thread.Sleep(800);
            }
        }
        public static void Stop()
        {
            Interlocked.Decrement(ref _counter);
            if (_counter == 0)
            {
                lock (Engine)
                {
                    Engine.Stop();
                }
            }
        }
    }
