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
        public static bool IsNet45OrNewer()
        {
            // Class "ReflectionContext" exists from .NET 4.5 onwards.
            return Type.GetType("System.Reflection.ReflectionContext", false) != null;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Is 4.5 or newer: " + IsNet45OrNewer());
            Console.WriteLine("IntPtr: " + IntPtr.Size);
            var t = new Test(2);
            t = null;
            new Test(3);
            Tester();
            Console.WriteLine("Pre GC");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("Post GC");
            Console.ReadKey();
        }
    }
