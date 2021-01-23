    using System;
    using System.Diagnostics;
    using System.Threading;
    namespace Demo
    {
        class Test
        {
            ~Test()
            {
                Thread.Sleep(250);
                Trace.WriteLine("In Test finalizer");
            }
        }
        class Program
        {
            static void Main()
            {
                var t = new Test[20];
                for (int i = 0; i < 20; ++i)
                    t[i] = new Test();
                //t = null;
                //GC.Collect();
                //GC.WaitForPendingFinalizers();
            }
        }
    }
