    using System;
    using System.Diagnostics;
    namespace CSharpStackArray
    {
        class Program
        {
            static void Main(string[] args)
            {
                int size = 8192;
                int reps = 10000;
                stackAlloc(size); // JIT
                Stopwatch clock = new Stopwatch();
                clock.Start();
                for (int i = 0; i < reps; i++)
                {
                    stackAlloc(size);
                }
                clock.Stop();
                string elapsed = clock.Elapsed.TotalMilliseconds.ToString("#,##0.####");
                string description = "C# stackalloc";
                Console.WriteLine("{0} ({1} bytes, {2} reps): {3:#,##0.####}ms", description, size, reps, elapsed);
                Console.ReadKey();
            }
            public unsafe static void stackAlloc(int arraySize)
            {
                byte* pArr = stackalloc byte[arraySize];
                for (int i = 0; i < arraySize; i++)
                {
                    pArr[i] = (byte)i;
                }
            }
        }
    }
