    using System;
    using System.Diagnostics;
    
    class Program {
        static void Main(string[] args) {
            string prcName = Process.GetCurrentProcess().ProcessName;
            var counter = new PerformanceCounter("Process", "Working Set - Private", prcName);
            Console.WriteLine("{0}K", counter.RawValue / 1024);
            Console.ReadLine();
        }
    }
