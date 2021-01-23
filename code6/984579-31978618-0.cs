    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
 
    class Program
    {
        static void Main()
        {
            for(;;)
            {
                uint startTick = GetTickCount();
                uint startIdle = GetIdleTime();
 
                Thread.Sleep(1000);
 
                uint stopTick = GetTickCount();
                uint stopIdle = GetIdleTime();
 
                uint percentIdle = (100 * (stopIdle - startIdle)) / stopTick - startTick);
 
                Console.WriteLine("CPU idle {0}%", percentIdle);
            }
        }
 
        [DllImport("coredll.dll")]
        static extern uint GetTickCount();
 
        [DllImport("coredll.dll")]
        static extern uint GetIdleTime();
    }
