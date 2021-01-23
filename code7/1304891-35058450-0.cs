    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        static class Program
        {
            static Random rng = new Random();
            static void Main()
            {
                // Simulate having a list of files.
                var fileList = Enumerable.Range(1, 100000).Select(i => i.ToString());
                // For demo purposes, cancel after a few seconds.
                var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                // Process files in parallel, with a maximum thread count.
                var opts = new ParallelOptions {MaxDegreeOfParallelism = 8, CancellationToken = source .Token};
                try
                {
                    Parallel.ForEach(fileList, opts, processFile);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Loop was cancelled.");
                }
            }
            static void processFile(string file)
            {
                Console.WriteLine("Processing file: " + file);
                // Simulate taking a varying amount of time per file.
                int delay;
                lock (rng)
                {
                    delay = rng.Next(200, 2000);
                }
                Thread.Sleep(delay);
                Console.WriteLine("Processed file: " + file);
            }
        }
    }
