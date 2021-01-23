    class Test
    {
        public int I { get; set; }
        ~Test()
        {
            Console.WriteLine("Collected " + I);
        }
    }
    static void Tester()
    {
        var t = new Test { I = 1 };
    }
    static void Main(string[] args)
    {
        Console.WriteLine(IntPtr.Size);
        
        var t = new Test { I = 2 };
        t = null;
        // or directly:
        // new Test { I = 2 };
        // no variable used
        Tester();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
