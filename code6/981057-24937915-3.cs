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
        }
    }
    class Engine
    {
        public void Start()
        {
            Console.WriteLine("{0:O} [{1}] Engine was started", DateTime.Now, Thread.CurrentThread.ManagedThreadId);
        }
        public void Stop()
        {
            Console.WriteLine("{0:O} [{1}] Engine was stopped", DateTime.Now, Thread.CurrentThread.ManagedThreadId);
        }
    }
    static class Lifecycle
    {
        private static Engine Engine;
        static Lifecycle()
        {
            Engine = new Engine();
        }
        public static void Start()
        {
            Monitor.Enter(Engine);
            Engine.Start();
            Thread.Sleep(800);
        }
        public static void Stop()
        {
            Engine.Stop();
            Monitor.Exit(Engine);
        }
    }
