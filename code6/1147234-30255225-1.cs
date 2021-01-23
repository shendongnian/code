    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            class Test
            {
                public readonly int I;
                public Test(int i)
                {
                    I = i;
                }
                ~Test()
                {
                    Console.WriteLine("Finalizer for " + I);
                }
            }
            static void Tester()
            {
                var t = new Test(1);
            }
            static void Main(string[] args)
            {
                Console.WriteLine("IntPtr: " + IntPtr.Size);
                var t = new Test(2);
                t = null;
                new Test(3);
                Tester();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Console.ReadKey();
            }
        }
    }
