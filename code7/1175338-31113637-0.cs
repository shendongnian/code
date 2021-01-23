    using System;
    using System.Threading;
    namespace Demo
    {
        public class Program
        {
            private static void Main()
            {
                bool value = false;
                int millseconds = new Random().Next(1000, 3001);
                var callback    = new Timer(dummy => { value = true; }, null, millseconds, -1);
                for (int i = 0; i < 100; ++i)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(value);
                }
            
                callback.Dispose();
            }
        }
    }
