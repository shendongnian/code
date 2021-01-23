    using System;
    using System.Collections.Generic;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public static int count = 0;
            public static List<string> numbers = new List<string>();
            public static int semaphore = 0;
    
            static void Main(string[] args)
            {
                for (int i = 0; i < 10; i++)
                {
                    numbers.Add(i.ToString());
                }
                Console.WriteLine("Before start thread");
                Thread tid1 = new Thread(new ThreadStart(MyThread.Thread1));
                Thread tid2 = new Thread(new ThreadStart(MyThread.Thread1));
    
                tid1.Start();
                tid2.Start();
    
                tid1.Join();
                tid2.Join();
            }
        }
        public class MyThread
        {
    
            public static void Thread1()
            {
                int nextIndex;
                while ((nextIndex = Interlocked.Increment(ref Program.count)) <= Program.numbers.Count)
                { 
                   Console.WriteLine(Program.numbers[nextIndex - 1]);
                }
            }
        }
    }
