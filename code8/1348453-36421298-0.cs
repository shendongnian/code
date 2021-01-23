    using System.IO;
    using System;
    using System.Diagnostics;
    
    class Program
    {
        static Stopwatch stopwatch = new Stopwatch();
        static TextWriter tw = new StreamWriter("Result.txt");
    
        public static void func(int i)
        {
        
            if (i > 40000)
                return;
            
            tw.WriteLine(stopwatch.ElapsedMilliseconds + " " + i);
            tw.Flush();
            func(i + 1);
        }
    
        static void Main(string[] args)
        {
            stopwatch.Start();
            func(0);
            stopwatch.Stop();
            tw.Close();
        }
    }
