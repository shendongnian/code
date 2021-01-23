    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            const int N = 1024;
    
            static void Main(string[] args)
            {
                int[,] a = new int[N, N];
    
                var stopwatch = Stopwatch.StartNew();
                for (int i = 0; i < N; i++)
                    for (int k = 0; k < N; k++)
                        for (int j = 0; j < N; j++)
                            a[i, j] = i+j;
                Console.WriteLine("Normal..: {0}", stopwatch.ElapsedMilliseconds);
    
                stopwatch = Stopwatch.StartNew();
                Parallel.For(0, N, i =>
                {
                    for (int k = 0; k < N; k++)
                        for (int j = 0; j < N; j++)
                            a[i, j] = i+j;
                });
                Console.WriteLine("Parallel: {0}", stopwatch.ElapsedMilliseconds);
    
                Console.ReadLine();
            }
        }
    }
