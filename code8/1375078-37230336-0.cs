    using System;
    using System.Threading;
    
    namespace StackOverflow_3_multithread_on_console
    {
        class Program
        {
            static Random _random = new Random();
    
            static void Main(string[] args)
            {
                var t1 = new Thread(Run1);
                var t2 = new Thread(Run2);
    
                t1.Start();
                t2.Start();
            }
    
            static void Run1()
            {
                for(int i = 0; i < 30; i++)
                {
                    Thread.Sleep(_random.Next(2000)); //for test
                    ConsoleLocker.Write("t1:" + i.ToString(), 0, i);
                }
            }
    
            static void Run2()
            {
                for (int i = 0; i < 30; i++)
                {
                    Thread.Sleep(_random.Next(2000)); //for test
                    ConsoleLocker.Write("t2:" + i.ToString(), 30, i);
                }
            }
        }
    
        static class ConsoleLocker
        {
            private static object _lock = new object();
    
            public static void Write(string s, int left, int top)
            {
                lock (_lock)
                {
                    Console.SetCursorPosition(left, top);
                    Thread.Sleep(100); //for test
                    Console.Write(s);
                }
            }
        }
    }
