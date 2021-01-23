    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main()
            {
                Stopwatch sw = new Stopwatch();
                int count = 200000;
                var test = new int[1000];
                for (int trial = 0; trial < 4; ++trial)
                {
                    sw.Restart();
                    for (int i = 0; i < count; ++i)
                        Power(test);
                    Console.WriteLine("Power() took " + sw.Elapsed);
                    sw.Restart();
                    for (int i = 0; i < count; ++i)
                        PowerNoLoop(test);
                    Console.WriteLine("PowerNoLoop() took " + sw.Elapsed);
                }
            }
            [MethodImpl(MethodImplOptions.NoOptimization)]
            public static void Power(int[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = arr[i] + arr[i];
                }
            }
            [MethodImpl(MethodImplOptions.NoOptimization)]
            public static void PowerNoLoop(int[] arr)
            {
                int i = 0;
                arr[i] = arr[i] + arr[i];
                ++i;
                <snip> Previous two lines repeated 1000 times.
            }
        }
    }
