    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Threading;
    namespace pi
    {
        
        class Program
        {        
            static void Main(string[] args)
            {
                object lockObject = new object();
                long num_steps = (long)1E9;
                double step = 1.0 / num_steps;
                for (int j = 1; j <= Environment.ProcessorCount; j++)
                {
                    double sum = 0.0;
                    Stopwatch timer = Stopwatch.StartNew();
                    Parallel.For(1, num_steps + 1, new ParallelOptions { MaxDegreeOfParallelism = j }, () => 0.0, (i, loopState, partialResult) =>
                    {
                        var x = (i - 0.5) * step;
                        return partialResult + 4.0 / (1.0 + x * x);
                    },
                    localPartialSum =>
                    {
                        lock (lockObject)
                        {
                            sum += localPartialSum;
                        }
                    });
                    var pi = step * sum;
                    timer.Stop();
                    Console.WriteLine($"{j} thread(s) ----> pi = {pi} calculated in {(timer.ElapsedMilliseconds)/1000.0} seconds");
                }
                Console.ReadKey();
            }
        }
    }
