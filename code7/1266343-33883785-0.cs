    using System;
    using System.Threading;
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000000; i++)
            {
                Thread CE = new Thread(SendCEcho);
                CE.Priority = ThreadPriority.Normal;
                CE.IsBackground = true;
                CE.Start();
                Thread.Sleep(500);
                CE = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        public static void SendCEcho()
        {
            int Counter = 0;
            for (int i = 0; i < 5; i++ )
            {
                Counter++;
                Thread.Sleep(25);
            }
        }
    }
